using System;
using WeBuyCars.LogicalLayer;

namespace WeBuyCars
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VehicleTypeLogicLayer.DisplayVehicleTypes();
            var vcode = Console.ReadLine();// search the Models and Makes for The vehicleType
            
            Console.ReadKey();
        }
    }
}
