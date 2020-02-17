using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
   public class VehicleType
    {
        public int Id {get;}
        public string VehicleTypeName {get;}

        public VehicleType(int id, string vehicleTypeName)
        {
            Id = id;
            VehicleTypeName = vehicleTypeName;
        }
    }
}
