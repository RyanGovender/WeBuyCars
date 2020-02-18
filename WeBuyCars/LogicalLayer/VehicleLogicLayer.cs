using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
    public class VehicleLogicLayer : Vehicle
    {
        private static double _returnDefaultAmount = 0;
        public static int MaxMillage = 999999;
        public static int MinMillage = 0;
        public static int minYear = 1886;
        public static double MaxValue = 10000000;

        public VehicleLogicLayer(int vehicleTypeId, int specs, int millage, int color, int serviceHistroy, double bookvalue, int year) : base(vehicleTypeId, specs, millage, color, serviceHistroy, bookvalue, year)
        {

        }

        public double CalculateTotalCost()
        {
          return BookValue + CalculateSericeHistoryCost() + CalculateSpecsCost() + CalculateMileageCost() + CalculateYearCost() + CalculateCostOfPaint();
        }

        public double CalculateSericeHistoryCost()
        {
            foreach (var item in DataLayer.GetServiceType())
            {
                if (item.Item1 == ServiceHistory && item.Item2 == VehicleTypeId) return BookValue * item.Item3;
            }
            return _returnDefaultAmount;
        }

        public double CalculateSpecsCost()
        {
            foreach (var item in DataLayer.GetSpecsCostData())
            {
                if (item.Key == Specs) return BookValue * item.Value;
            }
            return _returnDefaultAmount;
        }

        public double CalculateMileageCost()
        {
            foreach (var bracket in DataLayer.GetKmBracket())
            {
                if(Millage >= bracket.Item2 && Millage < bracket.Item3)
                {
                    foreach(var item in DataLayer.GetExtraCostForBracket())
                    {
                        if(item.Item1 == bracket.Item1 && item.Item2 == VehicleTypeId)
                        {
                            return  bracket.Item4 + bracket.Item4 * item.Item3;
                        }
                    }
                }
            }
            return _returnDefaultAmount;
        }

        public double CalculateYearCost()
        {
            foreach (var bracket in DataLayer.GetYearBrackets())
            {
                if(Year >= bracket.Item2 && Year < bracket.Item3 )
                {
                    foreach (var item in DataLayer.GetExtraCostForYearBracket())
                    {
                        if (item.Item1 == bracket.Item1 && item.Item2 == VehicleTypeId)
                        {
                            return (bracket.Item4) + bracket.Item4* item.Item3;
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
                if (item.Item1 == Color) return item.Item3;
            }
           return _returnDefaultAmount;
        }
    }
}
