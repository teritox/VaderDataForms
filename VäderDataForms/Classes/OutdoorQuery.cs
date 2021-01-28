using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VäderDataForms.Models;

namespace VäderDataForms.Classes
{
    class OutdoorQuery
    {
        private static List<string[]> ResultList = new List<string[]>();
        public static List<string[]> SearchOutdoors(DateTime date)
        {

            using (EFContext Context = new EFContext())
            {
                var entities = Context.OutdoorTemperatures
                    .Where(t => t.DateAndTime.Date == date)
                    .GroupBy(d => d.DateAndTime.Date, t => t.Temperature)
                    .Select(d => new
                    {
                        Date = d.Key,
                        Average = d.Average()
                    });

                ResultList.Clear();

                foreach (var temp in entities)
                {
                    string[] array = { $"{temp.Date.ToShortDateString()}", $"{Math.Round((decimal)temp.Average, 1)}" };
                    ResultList.Add(array);
                }
                return ResultList;

            }
        }

        public static List<string[]> SortWarmestDayOutdoor()
        {
            using (EFContext Context = new EFContext())
            {
                var averageTemp = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderByDescending(g => g.Avg);

                ResultList.Clear();

                foreach (var avgtemp in averageTemp)
                {
                    string[] array = { $"{avgtemp.Date.ToShortDateString()}", $"{Math.Round((decimal)avgtemp.Avg, 1)}" };
                    ResultList.Add(array);
                }
                return ResultList;
            }
        }
       

        public static List<string[]> SortMostAridDayOutdoor()
        {
            using (EFContext Context = new EFContext())
            {
                var averageHumidity = Context.OutdoorTemperatures
                    .Where(h => h.Humidity != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => (decimal)a.Humidity) })
                    .OrderBy(g => g.Avg);

                ResultList.Clear();

                foreach (var avgHumidity in averageHumidity)
                {
                    string[] array = { $"{avgHumidity.Date.ToShortDateString()}", $"{Math.Round((decimal)avgHumidity.Avg, 1)}" };
                    ResultList.Add(array);
                }
                return ResultList;
            }
        }

        public static List<string[]> LowestToHighestMoldOutdoor()
        {
            using (EFContext Context = new EFContext())
            {
                var averageMold = Context.OutdoorTemperatures
                    .Where(d => d.Humidity != null && d.Temperature != null)
                    .GroupBy(h => h.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, averageMold = Util.MoldCalc(g.Average(a => a.Humidity), g.Average(t => t.Temperature)) })
                    .ToList()
                    .OrderBy(m => m.averageMold);

                ResultList.Clear();

                foreach (var day in averageMold)
                {
                    string[] array = { $"{day.Date.ToShortDateString()}", $"{day.averageMold}%" };
                    ResultList.Add(array);
                }
                return ResultList;
            }
        }

        public static List<string[]> MeteorologicalAutumn()
        {
            using (EFContext Context = new EFContext())
            {
                var averageTemp = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();


                int daysInARow = 0;
                ResultList.Clear();

                for (int i = 0; i < averageTemp.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (averageTemp[i].Date.Month >= 8)
                        {
                            if (Math.Round((decimal)averageTemp[i + j].Avg, 1) > 0 && Math.Round((decimal)averageTemp[i + j].Avg, 1) < 10)
                            {
                                daysInARow++;
                            }
                            else
                            {
                                daysInARow = 0;
                                break;
                            }

                            if (daysInARow == 5)
                            {
                                string[] array = { $"{averageTemp[i].Date.ToShortDateString()}" };
                                ResultList.Add(array);
                                break;
                            }
                        }
                    }
                    if (daysInARow == 5)
                    {
                        break;
                    }
                }
                return ResultList;
            }
        }

        public static List<string[]> MeteorologicalWinter()
        {
            using (EFContext Context = new EFContext())
            {
                var averageTemp = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();

                int daysInARow = 0;

                DateTime spring = MeteorologicalSpring();
                ResultList.Clear();

                for (int i = 0; i < averageTemp.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (averageTemp[i].Date.Month >= 8 && averageTemp[i].Date.Month <= spring.Date.Month && averageTemp[i].Date.Day < spring.Date.Day)
                        {
                            if (Math.Round((decimal)averageTemp[i + j].Avg, 1) < 0)
                            {
                                daysInARow++;
                            }
                            else
                            {
                                daysInARow = 0;
                                break;
                            }

                            if (daysInARow == 5)
                            {
                                string[] array = { $"{averageTemp[i].Date.ToShortDateString()}" };
                                ResultList.Add(array);
                                break;
                            }
                        }
                    }
                    if (daysInARow == 5)
                    {
                        break;
                    }
                }
                string[] arrayNoDateFound = { "Inget datum hittades." };
                ResultList.Add(arrayNoDateFound);

                return ResultList;
            }
        }

        public static DateTime MeteorologicalSpring()
        {
            using (EFContext Context = new EFContext())
            {
                var averageTemp = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();


                int daysInARow = 0;

                for (int i = 0; i < averageTemp.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (averageTemp[i].Date.Month >= 2 && averageTemp[i].Date.Day >= 15)
                        {
                            if (Math.Round((decimal)averageTemp[i + j].Avg, 1) > 0 && Math.Round((decimal)averageTemp[i + j].Avg, 1) < 10)
                            {
                                daysInARow++;
                            }
                            else
                            {
                                daysInARow = 0;
                                break;
                            }

                            if (daysInARow == 7)
                            {
                                DateTime spring = averageTemp[i].Date;
                                return spring;
                            }
                        }
                    }
                    if (daysInARow == 7)
                    {
                        break;
                    }
                }
                return Convert.ToDateTime("0000-00-00");
            }
        }
    }
}
