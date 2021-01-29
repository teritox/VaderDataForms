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
                var entities = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderByDescending(g => g.Avg);

                ResultList.Clear();

                foreach (var avgtemp in entities)
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
                var entities = Context.OutdoorTemperatures
                    .Where(h => h.Humidity != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => (decimal)a.Humidity) })
                    .OrderBy(g => g.Avg);

                ResultList.Clear();

                foreach (var avgHumidity in entities)
                {
                    string[] array = { $"{avgHumidity.Date.ToShortDateString()}", $"{Math.Round((decimal)avgHumidity.Avg, 1)}" };
                    ResultList.Add(array);
                }
                return ResultList;
            }
        }

        public static List<string[]> SortLowestToHighestMoldOutdoor()
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.OutdoorTemperatures
                    .Where(d => d.Humidity != null && d.Temperature != null)
                    .GroupBy(h => h.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, averageMold = Util.MoldCalc(g.Average(a => a.Humidity), g.Average(t => t.Temperature)) })
                    .ToList()
                    .OrderBy(m => m.averageMold);

                ResultList.Clear();

                foreach (var day in entities)
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
                var entities = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();


                int daysInARow = 0;
                ResultList.Clear();

                //Since autumn can't fall before 1st of August and the temperature needs to be between 0 and 10 the algorith then counts to see if
                //there is 5 days in a row with a average temperature in that range. If 5 days in a row is found the first day is counted as the first day of autumn.
                for (int i = 0; i < entities.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (entities[i].Date.Month >= 8)
                        {
                            if (Math.Round((decimal)entities[i + j].Avg, 1) > 0 && Math.Round((decimal)entities[i + j].Avg, 1) < 10)
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
                                string[] array = { $"{entities[i].Date.ToShortDateString()}" };
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
                var entities = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();

                int daysInARow = 0;

                DateTime spring = MeteorologicalSpring();
                ResultList.Clear();

                //Same as the algorithm for autumn execept that a date for spring is calculated first since winter cannot occure after spring. 

                for (int i = 0; i < entities.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (entities[i].Date.Month >= 8 && entities[i].Date.Month <= spring.Date.Month && entities[i].Date.Day < spring.Date.Day)
                        {
                            if (Math.Round((decimal)entities[i + j].Avg, 1) < 0)
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
                                string[] array = { $"{entities[i].Date.ToShortDateString()}" };
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

        //Needed for calculating start of winter.
        public static DateTime MeteorologicalSpring()
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.OutdoorTemperatures
                    .Where(t => t.Temperature != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Temperature) })
                    .OrderBy(g => g.Date)
                    .ToList();


                int daysInARow = 0;

                //Same as the algorith for autumn except that spring cannot occure before the 15 february.
                //Used to calculate winter.

                for (int i = 0; i < entities.Count - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (entities[i].Date.Month >= 2 && entities[i].Date.Day >= 15)
                        {
                            if (Math.Round((decimal)entities[i + j].Avg, 1) > 0 && Math.Round((decimal)entities[i + j].Avg, 1) < 10)
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
                                DateTime spring = entities[i].Date;
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
