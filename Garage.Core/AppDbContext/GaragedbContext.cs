﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Garage.Core.Models;

#nullable disable

namespace Garage.Core.AppDbContext
{
    public partial class GaragedbContext : DbContext
    {
        public GaragedbContext()
        {
        }

        public GaragedbContext(DbContextOptions<GaragedbContext> options)
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
        public virtual DbSet<Hdr_StatutoryRequirement> Hdr_StatutoryRequirement { get; set; }
        public virtual DbSet<Trn_LogSheet> Trn_LogSheet { get; set; }

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
                entity.Property(e => e.ID).ValueGeneratedNever();

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
                entity.Property(e => e.ID).ValueGeneratedNever();

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

                entity.Property(e => e.Model).IsUnicode(false);

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