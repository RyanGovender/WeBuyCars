using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.LogicalLayer
{
   public class DataLayer
    {
        public static List<Tuple<int, int, double>> GetServiceType()
        {
            var list = new List<Tuple<int, int, double>>
            {
              new Tuple<int, int, double>(1,1,0.4), //First value is Serice type id , second value vehicle type id , percentage extra
              new Tuple<int, int, double>(2,1,0.3),
              new Tuple<int, int, double>(3,1,0),
              new Tuple<int, int, double>(1,2,0.55),
              new Tuple<int, int, double>(2,2,0.40),
              new Tuple<int, int, double>(3,2,0.05)
            };
            return list;
        }

        public static Dictionary<int,string> ServiceTypes()
        {
            var serviceTypes = new Dictionary<int, string>
            {
                {1,"Full Service History" },
                {2,"Partial Service History" },
                {3,"No Service Histroy" }
            };

            return serviceTypes;
        }

        public static Dictionary<int,string> SpecTypes()
        {
            var specs = new Dictionary<int, string>
            {
                {1,"High Spec" },
                {2,"Medium Spec" },
                {3,"Low Spec" }
            };

            return specs;
        }

        public static Dictionary<int,double> GetSpecsCostData()
        {
            var specsData = new Dictionary<int, double> // Specs Type - Extra cost
            {
                { 1, 0.3 },
                { 2, 0.15 },
                { 3, 0 }
            };
            return specsData;
        }

        public static List<Tuple<int,int, int, double>> GetKmBracket() // Bracket Id , Min km, Max Km, baseCost
        {
            var brackets = new List<Tuple<int, int, int, double>>{
                new Tuple<int, int, int, double>(1,0,100000,30000),
                new Tuple<int, int, int, double>(2,100000,150000,15000),
                new Tuple<int, int, int, double>(3,150000,int.MaxValue,5000)
            };
            return brackets;
        }

        public static List<Tuple<int,int,double>> GetExtraCostForBracket() // Bracket Id, vehicle type id, Extra cost
        {
            var extraCost = new List<Tuple<int, int, double>>
            {
                new Tuple<int, int, double>(1,1,0),
                new Tuple<int, int, double>(2,1,0),
                new Tuple<int, int, double>(3,1,0),
                new Tuple<int, int, double>(1,2,0.4),
                new Tuple<int, int, double>(2,2,0.3),
                new Tuple<int, int, double>(3,2,0.1),
            };
            return extraCost;
        }

        public static List<Tuple<int, int, int, double>> GetYearBrackets()
        {
            var brackets = new List<Tuple<int, int, int, double>>{
                new Tuple<int, int, int, double>(1,1886,2011,5000),
                new Tuple<int, int, int, double>(2,2011,2018,10000),
                new Tuple<int, int, int, double>(3,2019,DateTime.Now.Year,30000)
            };
            return brackets;
        }

        public static List<Tuple<int, int, double>> GetExtraCostForYearBracket() // Bracket Id, vehicle type id, Extra cost
        {
            var extraCost = new List<Tuple<int, int, double>>
            {
                new Tuple<int, int, double>(1,1,0),
                new Tuple<int, int, double>(2,1,0),
                new Tuple<int, int, double>(3,1,0),
                new Tuple<int, int, double>(1,2,0.15),
                new Tuple<int, int, double>(2,2,0.10),
                new Tuple<int, int, double>(3,2,0.05),
            };
            return extraCost;
        }

        public static List<Tuple<int,string,double>> GetPaintTypes()
        {
            var paintCost = new List<Tuple<int, string, double>>
            {
                new Tuple<int, string, double>(1,"Metalic",5000),
                new Tuple<int, string, double>(2,"Flat",0),
            };

            return paintCost;
        }

        public static Dictionary<int,int> PaintRestrictions()
        {
            var restrictions = new Dictionary<int, int>
            {
                {1,2 }
            };

            return restrictions;
        }
    }
}
