using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
    public class VehicleLogicLayer
    {
        private static double _returnDefaultAmount = 0;
        public static int MaxMillage = 999999;
        public static int MinMillage = 0;
        public static int minYear = 1886;
        public static double MaxValue = 10000000;
        private Vehicle _vehicle;

        public VehicleLogicLayer(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public double CalculateTotalCost()
        {
            return _vehicle.BookValue + CalculateSericeHistoryCost() + CalculateSpecsCost() + CalculateMileageCost() + CalculateYearCost() + CalculateCostOfPaint();
        }

        public double CalculateSericeHistoryCost()
        {
            foreach (var item in DataLayer.GetServiceType())
            {
                if (item.Item1 == _vehicle.ServiceHistory && item.Item2 == _vehicle.VehicleTypeId) return _vehicle.BookValue * item.Item3;
            }
            return _returnDefaultAmount;
        }

        public double CalculateSpecsCost()
        {
            foreach (var item in DataLayer.GetSpecsCostData())
            {
                if (item.Key == _vehicle.Specs) return _vehicle.BookValue * item.Value;
            }
            return _returnDefaultAmount;
        }

        public double CalculateMileageCost()
        {
            return DoMilleageOrYearCheck(DataLayer.GetKmBracket(), _vehicle.Millage,DataLayer.GetExtraCostForBracket());
        }

        public double CalculateYearCost()
        {
            return DoMilleageOrYearCheck(DataLayer.GetYearBrackets(), _vehicle.Year,DataLayer.GetExtraCostForYearBracket());
        }

        public double DoMilleageOrYearCheck(List<Tuple<int, int, int, double>> data, int value, List<Tuple<int, int, double>> extraCost)
        {
            foreach (var bracket in data)
            {
                if (value >= bracket.Item2 && value < bracket.Item3)
                {
                    foreach (var item in extraCost)
                    {
                        if (item.Item1 == bracket.Item1 && item.Item2 == _vehicle.VehicleTypeId)
                        {
                            return bracket.Item4 + bracket.Item4 * item.Item3;
                        }
                    }
                }
            }
            return _returnDefaultAmount;
        }
      
        public double CalculateCostOfPaint()
        {
            foreach (var item in DataLayer.GetPaintTypes())
            {
                if (item.Item1 == _vehicle.Color) return item.Item3;
            }
           return _returnDefaultAmount;
        }
    }
}
