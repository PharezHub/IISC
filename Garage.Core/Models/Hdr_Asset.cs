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
        public int? AssetTypeID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(30)]
        [Required]
        public string EngineNo { get; set; }
        [StringLength(30)]
        [Required]
        public string ChassisNo { get; set; }
        [StringLength(10)]
        [Required]
        public string RegNo { get; set; }
        [StringLength(30)]
        public string Make { get; set; }
        [StringLength(30)]
        public string ModelID { get; set; }
        public int? Year { get; set; }
        [StringLength(10)]
        public string EngineCapacity { get; set; }
        public int? FuelTypeID { get; set; }
        [StringLength(20)]
        public string Color { get; set; }
        public int? YearOfPurchase { get; set; }
        public double? InitialMileage { get; set; }
        public double? CurrentMileage { get; set; }
        public double? MileageLastService { get; set; }
        [Column(TypeName = "date")]
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
        [Column(TypeName = "date")]
        public DateTime? InsuranceExpiryDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RoadTaxExpiryDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FitnessExpiryDate { get; set; }
    }
}