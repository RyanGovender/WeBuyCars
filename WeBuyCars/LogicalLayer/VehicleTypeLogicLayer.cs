using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
    public class VehicleTypeLogicLayer
    {
        public static List<VehicleType> vehicleTypesList = GetVehicleTypes();

        public static List<VehicleType> GetVehicleTypes()
        {
            vehicleTypesList = new List<VehicleType>
            {
                new VehicleType(1,"Car"),
                new VehicleType(2,"Truck"),
                new VehicleType(3,"Bus")
            };
            return vehicleTypesList;
        }

        public static void DisplayVehicleTypes()
        {
            foreach (var item in vehicleTypesList)
            {
                Console.WriteLine($"\t({item.Id}) - {item.VehicleTypeName}");
            }
        }
    }
}
