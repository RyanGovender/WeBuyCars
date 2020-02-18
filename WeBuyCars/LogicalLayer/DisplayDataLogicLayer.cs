using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.LogicalLayer
{
   public class DisplayDataLogicLayer
    {
        public static void DisplayServiceTypes()
        {
            foreach(var item in DataLayer.ServiceTypes())
            {
                DisplayConsole(item.Key.ToString(), item.Value);
            }
        }

        public static void DisplayPaintTypes(int vehicleId)
        {
            foreach(var item in DataLayer.GetPaintTypes())
            {
              DisplayConsole(item.Item1.ToString(), item.Item2);
            }
        }

        public static void DisplaySpecsList()
        {
            foreach(var item in DataLayer.SpecTypes())
            {
                DisplayConsole(item.Key.ToString(), item.Value);
            }
        }

        private static void DisplayConsole(string item1, string item2)
        {
            Console.WriteLine($"\t({item1}) - {item2}");
        }
    }
}
