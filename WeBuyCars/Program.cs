﻿using System;
using WeBuyCars.LogicalLayer;
using WeBuyCars.Models;

namespace WeBuyCars
{
   public class Program
    {
        static void Main(string[] args)
        {
         
            VehicleTypeLogicLayer.DisplayVehicleTypes();
            var vcode = int.Parse(Console.ReadLine());// search the Models and Makes for The vehicleType
            ModelsLogicLayer.GetMakeBasedOnModel(vcode);
            var modelId = int.Parse(Console.ReadLine());
            ModelsLogicLayer.GetModels(modelId);

            var car = new Vehicle(vcode,1,20000,1,1,200000,2018);
            Console.ReadKey();
        }
    }
}
