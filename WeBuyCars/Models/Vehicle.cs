using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Vehicle
    {
        public int VehicleTypeId { get; }
        public int Specs { get;  }
        public int Millage { get; }
        public int Color { get; }
        public int ServiceHistory { get; }
        public double BookValue { get; }
        public int Year { get; }

        public Vehicle(int vehicleTypeId,int specs, int millage, int color, int serviceHistroy,double bookvalue, int year)
        {
            VehicleTypeId = vehicleTypeId;
            Specs = specs;
            Millage = millage;
            Color = color;
            ServiceHistory = serviceHistroy;
            BookValue = bookvalue;
            Year = year;
        }
    }
}
