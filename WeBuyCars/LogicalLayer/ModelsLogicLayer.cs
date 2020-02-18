using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
   public class ModelsLogicLayer
    {
        public static List<Model> modelsList = GetAllModels();
        private static List<int> makeIdList = new List<int>();
        public static int MinId = 0;
        public static int MaxId = 0;
        public static int VehicleTypeCount = 0;
        private static int _minValue = 0;
        public static string NotSureValue = "*";

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
                new Model(8,3,"M3",1),
                new Model(9,1,"H2000",2)
            };
            return modelsList;
        }

        public static void GetMakeBasedOnModel(int vehicletypeId)
        {
            foreach (var item in modelsList)
            {
                if(item.VehicleTypeId == vehicletypeId && !makeIdList.Contains(item.MakeId))
                {
                    VehicleTypeCount++;
                    Console.WriteLine($"\t({item.MakeId}) - {MakeLogicLayer.GetMake(item.MakeId)}");
                    makeIdList.Add(item.MakeId);
                }
            }
        }

        public static void GetModels(int makeId,int vehicleType)
        {
            foreach (var item in modelsList)
            {
                if(item.MakeId == makeId && vehicleType== item.VehicleTypeId)
                {
                    if (MinId == _minValue) MinId = item.Id;
                    Console.WriteLine($"\t({item.Id}) - {item.ModelName}");
                    MaxId=item.Id;
                }
            }
            Console.WriteLine($"\t({NotSureValue}) - Not Sure");
        }
    }
}
