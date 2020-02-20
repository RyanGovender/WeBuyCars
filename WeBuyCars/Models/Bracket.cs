using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Bracket
    {
        public int Id { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int BaseCost { get; set; }

        public Bracket(int v1, int v2, int v3, int v4)
        {
            Id = v1;
            MinValue = v2;
            MaxValue = v3;
            BaseCost = v4;
        }
    }

    public class ExtraCostBracket
    {
        public int BracketId { get; set; }
        public int VehicleTypeId { get; set; }
        public double ExtraCost { get; set; }

        public ExtraCostBracket(int bracketId, int vehicleId, double extraCostPercentage)
        {
            BracketId = bracketId;
            VehicleTypeId = vehicleId;
            ExtraCost = extraCostPercentage;
        }
    }
}
