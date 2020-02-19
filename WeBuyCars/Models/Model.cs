using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Model
    {
        public int Id { get;}
        public int VehicleTypeId { get; }
        public int MakeId { get; }
        public string ModelName { get; }

        public Model(int id, int makeId, string modelName,int vehicleTypeId)
        {
            Id = id;
            MakeId = makeId;
            ModelName = modelName;
            VehicleTypeId = vehicleTypeId;
        }
    }
}
