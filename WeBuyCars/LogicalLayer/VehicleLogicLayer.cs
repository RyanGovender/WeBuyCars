using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

namespace WeBuyCars.LogicalLayer
{
    public class VehicleLogicLayer : Vehicle
    {
        private static double _returnDefaultAmount = 0;

        public VehicleLogicLayer(int vehicleTypeId, int specs, int millage, int color, int serviceHistroy, double bookvalue, int year) : base(vehicleTypeId, specs, millage, color, serviceHistroy, bookvalue, year)
        {
        }

        public double CalculateSericeHistoryCost(int serviceId, int vehicleTypeId, double basePrice)
        {
            foreach (var item in DataLayer.GetServiceType())
            {
                if (item.Item1 == serviceId && item.Item1 == vehicleTypeId) return basePrice * item.Item3;
            }
            return _returnDefaultAmount;
        }

        public double CalculateSpecsCost(int specs, double basePrice)
        {
            foreach (var item in DataLayer.GetSpecsCostData())
            {
                if (item.Key == specs) return basePrice * item.Value;
            }
            return _returnDefaultAmount;
        }

        public double CalculateMileageCost(int km, double basePrice,int vehicleId)
        {
            foreach (var bracket in DataLayer.GetKmBracket())
            {
                if(km >= bracket.Item2 && km< bracket.Item3)
                {
                    foreach(var item in DataLayer.GetExtraCostForBracket())
                    {
                        if(item.Item1 == bracket.Item1 && item.Item2 == vehicleId)
                        {
                            return (basePrice + bracket.Item3) + bracket.Item3 * item.Item3;
                        }
                    }
                }
            }
            return _returnDefaultAmount;
        }

        public double CalculateYearCost(int year, double basePrice,int vehicleId)
        {
            foreach (var bracket in DataLayer.GetYearBrackets())
            {
                if(year >= bracket.Item2 && year < bracket.Item3 )
                {
                    foreach (var item in DataLayer.GetExtraCostForYearBracket())
                    {
                        if (item.Item1 == bracket.Item1 && item.Item2 == vehicleId)
                        {
                            return (basePrice + bracket.Item3) + bracket.Item3* item.Item3;
                        }
                    }
                }
            }
            return _returnDefaultAmount;
        }

        public double CalculateCostOfPaint(int paintType, double basePrice)
        {
            foreach (var item in DataLayer.GetPaintTypes())
            {
                if (item.Item1 == paintType) return basePrice + item.Item3;
            }
           return _returnDefaultAmount;
        }
    }
}
