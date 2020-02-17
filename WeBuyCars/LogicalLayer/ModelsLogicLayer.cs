using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
   public class ModelsLogicLayer
    {
        public static List<Model> modelsList = GetAllModels();

        public static List<Model> GetAllModels()
        {
            modelsList = new List<Model>
            {
                new Model(1,1,"Corolla",1),
                new Model(2,1,"Yaris",1),
                new Model(3,1,"86",1),
                new Model(4,1,"Aygo",1),
                new Model(5,2,"A45",1),
                new Model(6,2,"C200",1),
                new Model(7,2,"CLA45",1),
                new Model(8,3,"M3",1)
            };
            return modelsList;
        }
    }
}
