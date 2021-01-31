using Garage.Core.AppDbContext;
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

        public void AddPartsCatalog(AdmPartsCatalog catalog)
        {
            try
            {
                if (catalog != null)
                {
                    _context.AdmPartsCatalog.Add(catalog);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void DeletePartCatalog(int id)
        {
            try
            {
                var query = _context.AdmPartsCatalog.FirstOrDefault(x => x.ID == id);
                if (query != null)
                {
                    query.IsDeleted = true;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AssetViewModel GetAssetById(int Id)
        {
            try
            {
                var query = _context.AssetViewModel.FromSqlRaw("spGetAssetById {0}", Id).ToList();
                if (query != null)
                {
                    return query.FirstOrDefault();
                }

                return null;
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

        public IEnumerable<PartsCatalogViewModel> GetPartsCatalog()
        {
            return _context.PartsCatalogViewModel.FromSqlRaw("spGetPartsCatalog").ToList();
        }

        public AdmPartsCatalog GetPartsCatalogById(int Id)
        {
            return _context.AdmPartsCatalog.Find(Id);
        }

        public IEnumerable<AssetCatalogueViewModel> OffSiteUtilization()
        {
            return _context.AssetCatalogueViewModel
                .FromSqlRaw("spOffSiteUtilization")
                .ToList();
        }

        public IEnumerable<AssetCatalogueViewModel> OnSiteUtilization()
        {
            return _context.AssetCatalogueViewModel
                .FromSqlRaw("spOnSiteUtilization")
                .ToList();
        }

        public void UpdatePartsCatalog(AdmPartsCatalog catalog)
        {
            try
            {
                var query = _context.AdmPartsCatalog.FirstOrDefault(x => x.ID == catalog.ID);
                if (query != null)
                {
                    query.ItemDescription = catalog.ItemDescription.Trim();
                    query.CategoryID = catalog.CategoryID;
                    query.MakeID = catalog.MakeID;
                    query.ModelID = catalog.ModelID;
                    query.PartNumber = catalog.PartNumber.Trim();
                    query.Comment = catalog.Comment.Trim();
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateEngineNumber(string engineNo)
        {
            bool exists = false;
            var query = _context.Hdr_Asset.FirstOrDefault(x => x.EngineNo.Trim().ToUpper() == engineNo.Trim().ToUpper());
            if (query != null)
                exists = true;

            return exists;
        }

        public bool ValidatePartCatalog(string itemDescription, int categoryId, int modelId, int makeId)
        {
            var query = _context.AdmPartsCatalog.FirstOrDefault(x => x.ItemDescription.Trim().ToUpper() == itemDescription.Trim().ToUpper()
            && x.CategoryID == categoryId
            && x.ModelID == modelId
            && x.MakeID == makeId);

            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateRegNumber(string regNo)
        {
            bool exists = false;
            var query = _context.Hdr_Asset.FirstOrDefault(x => x.RegNo.Trim().ToUpper() == regNo.Trim().ToUpper());
            if (query != null)
                exists = true;

            return exists;
        }
    }
}
