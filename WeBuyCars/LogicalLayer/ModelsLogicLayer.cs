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
                new Model(1,1,"Corolla"),
                new Model(2,1,"Yaris"),
                new Model(3,1,"86"),
                new Model(4,1,"Aygo"),
                new Model(5,2,"A45"),
                new Model(6,2,"C200"),
                new Model(7,2,"CLA45"),
                new Model(8,3,"M3")
            };
            return modelsList;
        }
    }
}
