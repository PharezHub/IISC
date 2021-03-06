﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Garage.Core.Models;
using Garage.Core.ViewModel;

#nullable disable

namespace Garage.Core.AppDbContext
{
    public partial class GarageDbContext : DbContext
    {
        public GarageDbContext(DbContextOptions<GarageDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adm_AssetCategory> Adm_AssetCategory { get; set; }
        public virtual DbSet<Adm_AssetType> Adm_AssetType { get; set; }
        public virtual DbSet<Adm_CategoryStatutoryLink> Adm_CategoryStatutoryLink { get; set; }
        public virtual DbSet<Adm_Frequency> Adm_Frequency { get; set; }
        public virtual DbSet<Adm_FuelType> Adm_FuelType { get; set; }
        public virtual DbSet<Adm_InsuranceType> Adm_InsuranceType { get; set; }
        public virtual DbSet<Adm_LogSheetType> Adm_LogSheetType { get; set; }
        public virtual DbSet<Adm_MaintenanceType> Adm_MaintenanceType { get; set; }
        public virtual DbSet<Adm_ManageLogSheet> Adm_ManageLogSheet { get; set; }
        public virtual DbSet<Adm_ManageTrigger> Adm_ManageTrigger { get; set; }
        public virtual DbSet<Adm_Statutory> Adm_Statutory { get; set; }
        public virtual DbSet<Adm_TriggerType> Adm_TriggerType { get; set; }
        public virtual DbSet<Hdr_Asset> Hdr_Asset { get; set; }
        public virtual DbSet<AdmPartsCatalog> AdmPartsCatalog { get; set; }
        public  virtual DbSet<Adm_Make> Adm_Make { get; set; }
        public virtual DbSet<Adm_Model> Adm_Model { get; set; }
        public virtual DbSet<Hdr_StatutoryRequirement> Hdr_StatutoryRequirement { get; set; }
        public virtual DbSet<Trn_LogSheet> Trn_LogSheet { get; set; }
        public virtual DbSet<Gen_SystemArea> Gen_SystemArea { get; set; }
        public virtual DbSet<HdrMaintenance> HdrMaintenance { get; set; }
        public virtual DbSet<TrnPartUsed> TrnPartUsed { get; set; }
        public virtual DbSet<TrnSpecialTools> TrnSpecialTools { get; set; }
        public virtual DbSet<WorkOrderHdr> WorkOrderHdr { get; set; }
        public virtual DbSet<AdmGroupType> AdmGroupType { get; set; }
        public virtual DbSet<TrnWorkOrderParts> TrnWorkOrderParts { get; set; }
        public virtual DbSet<AdmPriority> AdmPriority { get; set; }
        public virtual DbSet<AdmPurpose> AdmPurpose { get; set; }
        public virtual DbSet<AdmReason> AdmReason { get; set; }
        public virtual DbSet<AdmSection> AdmSection { get; set; }
        public virtual DbSet<Trn_Attachments> Trn_Attachments { get; set; }
        public virtual DbSet<TrnFuelConsumption> TrnFuelConsumption { get; set; }
        public virtual DbSet<Adm_AttachmentTypes> Adm_AttachmentTypes { get; set; }
        public virtual DbSet<TrnFuelPriceHistory> TrnFuelPriceHistory { get; set; }
        public virtual DbSet<AXAutoMobile> AXAutoMobile { get; set; }
        public virtual DbSet<zRole> zRole { get; set; }
        public virtual DbSet<zRoleUser> zRoleUser { get; set; }
        public virtual DbSet<zUsers> zUsers { get; set; }
        public virtual DbSet<RoleUserViewModel> RoleUserViewModel { get; set; }
        public DbSet<FuelPriceHistoryViewModel> FuelPriceHistoryViewModel { get; set; }
        public DbSet<StatutoryCategoryViewModel> StatutoryCategoryViewModel { get; set; }
        public DbSet<AssetCatalogueViewModel> AssetCatalogueViewModel { get; set; }
        public DbSet<AssetViewModel> AssetViewModel { get; set; }
        public DbSet<MaintenanceTriggerListViewModel> MaintenanceTriggerListViewModel { get; set; }
        public DbSet<MaintenanceTags> MaintenanceTags { get; set; }
        public DbSet<LogSheetSetupViewModel> LogSheetSetupViewModel { get; set; }
        public DbSet<LogSheetListViewModel> LogSheetListViewModel { get; set; }
        public DbSet<PartsCatalogViewModel> PartsCatalogViewModel { get; set; }
        public DbSet<HdrMaintenanceViewModel> HdrMaintenanceViewModel { get; set; }
        public DbSet<PartUsedViewModel> PartUsedViewModel { get; set; }
        public DbSet<WorkOrderHdrViewModel> WorkOrderHdrViewModel { get; set; }
        public DbSet<MaintenanceTriggerSummaryViewModel> MaintenanceTriggerSummaryViewModel { get; set; }
        public DbSet<FuelConsumptionViewModel> FuelConsumptionViewModel { get; set; }
        public DbSet<AXAutoMobileViewModel> AXAutoMobileViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Adm_AssetCategory>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_AssetType>(entity =>
            {
                entity.Property(e => e.AssetType).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_CategoryStatutoryLink>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_Frequency>(entity =>
            {
                entity.Property(e => e.FrequencyName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_FuelType>(entity =>
            {
                entity.Property(e => e.FuelName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_InsuranceType>(entity =>
            {
                entity.Property(e => e.InsuranceName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_LogSheetType>(entity =>
            {
                entity.Property(e => e.LogSheetName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_MaintenanceType>(entity =>
            {
                entity.Property(e => e.MaintenanceName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_ManageLogSheet>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_ManageTrigger>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_Statutory>(entity =>
            {
                entity.Property(e => e.StatutoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Adm_TriggerType>(entity =>
            {
                entity.Property(e => e.TriggerName).IsUnicode(false);
            });

            modelBuilder.Entity<Hdr_Asset>(entity =>
            {
                entity.Property(e => e.ChassisNo).IsUnicode(false);

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.EngineCapacity).IsUnicode(false);

                entity.Property(e => e.EngineNo).IsUnicode(false);

                entity.Property(e => e.Make).IsUnicode(false);

                entity.Property(e => e.ModelID).IsUnicode(false);

                entity.Property(e => e.RegNo).IsUnicode(false);

                entity.Property(e => e.TagNo).IsUnicode(false);
            });

            modelBuilder.Entity<Hdr_StatutoryRequirement>(entity =>
            {
                entity.Property(e => e.ChassisNo).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.InsuranceCompany).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);

                entity.Property(e => e.RegNo).IsUnicode(false);
            });

            modelBuilder.Entity<Trn_LogSheet>(entity =>
            {
                entity.Property(e => e.ModifiedBy).IsUnicode(false);

                entity.Property(e => e.RegNo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}