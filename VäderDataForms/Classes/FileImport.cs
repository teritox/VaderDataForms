using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VäderDataForms.Models;

namespace VäderDataForms.Classes
{
    class FileImport
    {
        public static void ImportTemperatures()
        {
            if (File.Exists("TemperaturData.csv"))
            {
                string text = File.ReadAllText("TemperaturData.csv");
                string[] dataLines = text.Split("\r");
                Console.WriteLine(dataLines.Length);

                using (EFContext Context = new EFContext())
                {

                    if (Context.IndoorTemperatures.Count() == 0)
                    {
                        foreach (string data in dataLines)
                        {
                            string[] keyValue = data.Split(",");

                            CultureInfo culture = new CultureInfo("en-US");

                            //Seperates datalines into two different tables, one for indoor and one for outdoors.
                            try
                            {
                                if (keyValue[1] == "Ute")
                                {
                                    var outdoorTemp = new OutdoorTemperature();
                                    outdoorTemp.DateAndTime = Convert.ToDateTime(keyValue[0]);
                                    outdoorTemp.Temperature = keyValue[2] == "" ? (decimal?)null : Convert.ToDecimal(keyValue[2], culture);
                                    outdoorTemp.Humidity = keyValue[3] == "" ? (decimal?)null : Convert.ToDecimal(keyValue[3], culture);
                                    Context.OutdoorTemperatures.Add(outdoorTemp);
                                }
                                else if (keyValue[1] == "Inne")
                                {
                                    var indoorTemp = new IndoorTemperature();
                                    indoorTemp.DateAndTime = Convert.ToDateTime(keyValue[0]);
                                    indoorTemp.Temperature = keyValue[2] == "" ? (decimal?)null : Convert.ToDecimal(keyValue[2], culture);
                                    indoorTemp.Humidity = keyValue[3] == "" ? (decimal?)null : Convert.ToDecimal(keyValue[3], culture);
                                    Context.IndoorTemperatures.Add(indoorTemp);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("En rad ur den inlästa filen kunde inte importeras.");
                            }

                        }
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
