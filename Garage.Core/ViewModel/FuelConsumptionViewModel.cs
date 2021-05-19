using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class FuelConsumptionViewModel
    {
        public int ID { get; set; }
        public string RegNo { get; set; }
        public int AssetID { get; set; }
        public double OdometerReading { get; set; }
        public double PreviousReading { get; set; }
        public double LitresReceived { get; set; }
        public double CurrentFuelPrice { get; set; }
        public double TotalCost { get; set; }
        public double PlannedConsumption { get; set; }
        public double TankCapacity { get; set; }
        public double KMs { get; set; }
        public double ActualKmL { get; set; }
        public double CapacityVariance { get; set; }
        public double PlannedLts { get; set; }
        public double TotalLtsOverConsumption { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string FuelName { get; set; }
        public string GroupName { get; set; }
        public string AssetStatus { get; set; }
        public string CategoryName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string OperatorID { get; set; }
    }
}
