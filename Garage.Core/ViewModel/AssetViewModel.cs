using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class AssetViewModel
    {
        public int ID { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetType { get; set; }
        public int CategoryID { get; set; }
        public double PlannedConsumption { get; set; }
        public double TankCapacity { get; set; }
        public int GroupID { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string RegNo { get; set; }
        public double CurrentMileage { get; set; }
        public string Make { get; set; }
        public string MakeName { get; set; }
        public string ModelID { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public string EngineCapacity { get; set; }
        public int FuelTypeID { get; set; }
        public string FuelName { get; set; }
        public string Color { get; set; }
        public int YearOfPurchase { get; set; }
        public double InitialMileage { get; set; }
        public double Difference { get; set; }
        public double AssetValue { get; set; }
        public string? TagNo { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public DateTime? RoadTaxExpiryDate { get; set; }
        public DateTime? FitnessExpiryDate { get; set; }
        public double MileageLastService { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastServiceDate { get; set; }

    }
}
