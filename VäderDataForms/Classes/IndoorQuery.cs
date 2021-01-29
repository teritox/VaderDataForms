using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VäderDataForms.Models;

namespace VäderDataForms.Classes
{
    class IndoorQuery
    {
        private static List<string[]> ResultList = new List<string[]>();

        public static List<string[]> SearchIndoors(DateTime date)
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.IndoorTemperatures
                    .Where(t => t.Temperature != null)
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
        public static List<string[]> SortWarmestDayIndoor()
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.IndoorTemperatures
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

        public static List<string[]> SortMostAridDayIndoor()
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.IndoorTemperatures
                    .Where(t => t.Humidity != null)
                    .GroupBy(a => a.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, Avg = g.Average(a => a.Humidity) })
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

        public static List<string[]> SortLowestToHighestMoldIndoor()
        {
            using (EFContext Context = new EFContext())
            {
                var entities = Context.IndoorTemperatures
                    .Where(d => d.Temperature != null && d.Humidity != null)
                    .GroupBy(h => h.DateAndTime.Date)
                    .Select(g => new { Date = g.Key, averageMold = Util.MoldCalc(g.Average(a => a.Humidity), g.Average(t => t.Temperature)) })
                    .ToList()
                    .OrderByDescending(m => m.averageMold);

                ResultList.Clear();

                foreach (var day in entities)
                {
                    string[] array = { $"{day.Date.ToShortDateString()}", $"{Math.Round(day.averageMold)}%" };
                    ResultList.Add(array);
                }
                return ResultList;
            }
        }
    }
}
