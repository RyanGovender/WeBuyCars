using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public int MakeId { get; set; }
        public string ModelName { get; set; }

        public Model(int id, int makeId, string modelName,int vehicleTypeId)
        {
            Id = id;
            MakeId = makeId;
            ModelName = modelName;
            VehicleTypeId = vehicleTypeId;
        }
    }
}
