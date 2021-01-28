using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VäderDataForms.Classes
{
    class Util
    {
        public static double MoldCalc(decimal? decHumidity, decimal? decTemp)
        {
            double humidity = (double)decHumidity;
            double temperature = (double)decTemp;

            double risk = ((humidity - 78) * (temperature / 15)) / 0.22;
            risk = Math.Round(risk);

            if (risk > 100)
            {
                return 100;
            }
            else if (risk <= 0)
            {
                return 0;
            }
            else
            {
                return risk;
            }
        }
    }
}
