using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
   public class MakeLogicLayer
    {
        public static List<Make> MakesList = GetAllMakes();

        public static List<Make> GetAllMakes()
        {
            MakesList = new List<Make>
            {
                new Make(1,"Toyota"),
                new Make(3,"BMW"),
                new Make(2,"Mercedes")
            };
            return MakesList;
        }

        public static string GetMake(int makeId)
        {
            foreach(var item in MakesList)
            {
                if (item.Id == makeId) return item.MakeName;
            }
            return "";
        }
    }
}
