﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Garage.Core.Models
{
    public partial class Hdr_Asset
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Asset type is required")]
        [Range(1,50,ErrorMessage = "Asset type is required")]
        public int AssetTypeID { get; set; }

        [Required(ErrorMessage = "Asset Group is required")]
        [Range(1, 2, ErrorMessage = "Asset Group is required")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Planned consumption is required")]
        [Range(1, 10000, ErrorMessage = "Planned consumption is out of range")]
        public float PlannedConsumption { get; set; }

        [Required(ErrorMessage = "Asset category is required")]
        [Range(1, 50, ErrorMessage = "Asset category is required")]
        public int CategoryID { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Engine number is required")]
        public string EngineNo { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Chassis number is required")]
        public string ChassisNo { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Registration/Plate number is required")]
        public string RegNo { get; set; }

        [StringLength(30)]
        [Range(1, 50, ErrorMessage = "Select Make from the list")]
        public string Make { get; set; }

        [StringLength(30)]
        [Range(1, 50, ErrorMessage = "Select Model from the list")]
        public string ModelID { get; set; }

        [Required(ErrorMessage = "Enter valid manufacture year")]
        [Range(1000, 5000, ErrorMessage = "Enter valid manufacture year")]
        public int Year { get; set; }

        [StringLength(10)]
        public string EngineCapacity { get; set; }

        [Range(1, 50, ErrorMessage = "Select Model from the list")]
        public int FuelTypeID { get; set; }

        [StringLength(20)]
        [Range(1, 50, ErrorMessage = "Select Color from the list")]
        public string Color { get; set; }

        [Range(1000, 5000, ErrorMessage = "Enter valid purchase year")]
        public int? YearOfPurchase { get; set; }
        public double? InitialMileage { get; set; }

        [Required(ErrorMessage = "Enter Tank Capacity")]
        [Range(10, 1000, ErrorMessage = "Enter a valid tank capacity from 10 - 1000 litres")]
        public double TankCapacity { get; set; }
        public double? CurrentMileage { get; set; }
        public double? MileageLastService { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastServiceDate { get; set; }
        public double? AssetValue { get; set; }
        [StringLength(30)]
        public string TagNo { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        public int? AssetStatus { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? InsuranceExpiryDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RoadTaxExpiryDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FitnessExpiryDate { get; set; }
        public string FolderID { get; set; }
    }
}