﻿using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage.Core.Services
{
    public class AssetService : IAssetRepository
    {
        private readonly GarageDbContext _context;

        public AssetService(GarageDbContext context)
        {
            this._context = context;
        }

        public void AddStatutory(Hdr_StatutoryRequirement statutoryRequirement)
        {
            try
            {
                _context.Hdr_StatutoryRequirement.Add(statutoryRequirement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AssetCatalogueViewModel> GetAssetCatelogueList()
        {
            return _context.AssetCatalogueViewModel
                .FromSqlRaw("spGetAssetCatelogue")
                .ToList();
        }

        public List<Adm_InsuranceType> GetInsuranceType()
        {
            return _context.Adm_InsuranceType.ToList();
        }
    }
}
