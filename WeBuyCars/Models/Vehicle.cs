using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Vehicle
    {
        public int Id { get; }
        public int VehicleTypeId { get; set; }
        public int ModelId { get; }
        public string Specs { get; set; }
        public int Millage { get; }
        public string Color { get; }
        public string ServiceHistory { get; }
        public double BookValue { get; }
        public int Year { get; }


        
    }
}
