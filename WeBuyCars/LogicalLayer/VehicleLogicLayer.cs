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

        private double CalculateSericeHistoryCost()
        {
            foreach (var item in DataLayer.GetServiceType())
            {
                if (item.Item1 == _vehicle.ServiceHistory && item.Item2 == _vehicle.VehicleTypeId) return _vehicle.BookValue * item.Item3;
            }
            return _returnDefaultAmount;
        }

        private double CalculateSpecsCost()
        {
            foreach (var item in DataLayer.GetSpecsCostData())
            {
                if (item.Key == _vehicle.Specs) return _vehicle.BookValue * item.Value;
            }
            return _returnDefaultAmount;
        }

        private double CalculateMileageCost()
        {
            return DoMilleageOrYearCheck(DataLayer.GetKmBracket(), _vehicle.Millage,DataLayer.GetExtraCostBrackets());
        }

        private double CalculateYearCost()
        {
            return DoMilleageOrYearCheck(DataLayer.GetYearBrackets(), _vehicle.Year,DataLayer.GetExtraCostBracketsForYear());
        }

        private double DoMilleageOrYearCheck(List<Bracket> data, int value, List<ExtraCostBracket> extraCost)
        {
            foreach (var bracket in data)
            {
                if (value >= bracket.MinValue && value < bracket.MaxValue)
                {
                  return bracket.BaseCost + bracket.BaseCost * GetExtraCostBasedOnVehicleType(bracket.Id,extraCost);
                }
            }
            return _returnDefaultAmount;
        }

        public double GetExtraCostBasedOnVehicleType(int bracketId,List<ExtraCostBracket> extra)
        {
            var item = extra.Find(x => x.BracketId == bracketId && x.VehicleTypeId == _vehicle.VehicleTypeId);
            if (extra.Contains(item))
            {
                return item.ExtraCost;
            }
            return _returnDefaultAmount;  
        }

        private double CalculateCostOfPaint()
        {
            foreach (var item in DataLayer.GetPaintTypes())
            {
                if (item.Item1 == _vehicle.Color) return item.Item3;
            }
           return _returnDefaultAmount;
        }

        public static bool ChecKPaintRestrictions(int vehicleTypeId, int paint)
        {
            foreach(var item in DataLayer.PaintRestrictions())
            {
                if (item.Value == vehicleTypeId && item.Key == paint) return true;
            }
            return false;
        }

        public void DisplayVehicleReport(int makeId)
        {
            DataLayer.SpecTypes().TryGetValue(_vehicle.Specs, out string specs);
            DataLayer.ServiceTypes().TryGetValue(_vehicle.ServiceHistory, out string service);

            Console.WriteLine($"\nMake : {MakeLogicLayer.GetMake(makeId)}" +
                $"\nModel : {ModelsLogicLayer.GetModelName((int)_vehicle.ModelId)}" +
                $"\nYear : {_vehicle.Year}" +
                $"\nMillage : {_vehicle.Millage}km" +
                $"\nSpecs : {specs}" +
                $"\nService Histrtoy : {service}" +
                $"\nBook Value : {_vehicle.BookValue}" +
                $"\nSelling Price : R{CalculateTotalCost()}");
        }
    }
}
