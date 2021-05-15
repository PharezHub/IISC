using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddStatutory(Hdr_StatutoryRequirement statutory)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("spAddStatutory {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", statutory.AssetID,
                    statutory.RegNo, statutory.ChassisNo, statutory.StatutoryID, statutory.StatutoryAvailable, statutory.InsuranceTypeID, statutory.InsuranceCompany,
                    statutory.AmountPaid, statutory.DateFrom, statutory.DateTo, statutory.FileName, statutory.ModifiedBy);
                //_context.Hdr_StatutoryRequirement.Add(statutoryRequirement);
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

        public string GenerateGuid()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
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

        public async Task<Hdr_Asset> GetAssetDetailById(int Id)
        {
            return await _context.Hdr_Asset.FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<IEnumerable<Adm_AttachmentTypes>> GetAttachmentTypes()
        {
            return await _context.Adm_AttachmentTypes.ToListAsync();
        }

        public async Task<string> GetGuid(int assetId)
        {
            try
            {
                return await _context.Hdr_Asset.Where(x => x.ID == assetId).Select(x => x.FolderID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Adm_InsuranceType> GetInsuranceType()
        {
            return _context.Adm_InsuranceType.ToList();
        }

        public IEnumerable<AdmPartsCatalog> GetPartByCategory(int categoryId, int modelId, int makeId)
        {
           return _context.AdmPartsCatalog.Where(x => x.CategoryID == categoryId
            && x.ModelID == modelId
            && x.MakeID == makeId).ToList();
        }

        public IEnumerable<PartsCatalogViewModel> GetPartsCatalog()
        {
            return _context.PartsCatalogViewModel.FromSqlRaw("spGetPartsCatalog").ToList();
        }

        public AdmPartsCatalog GetPartsCatalogById(int Id)
        {
            return _context.AdmPartsCatalog.Find(Id);
        }

        public async Task<List<int>> GetStatutorybyCategoryId(int categoryId)
        {
            List<int> statutoryList = new List<int>();
            var result = await _context.Adm_CategoryStatutoryLink.Where(x => x.CategoryID == categoryId).Select(x => x.StatutoryID).Distinct().ToListAsync();
            foreach (var item in result)
            {
                statutoryList.Add(item.Value);
            }

            return statutoryList;
        }

        public async Task<List<Hdr_StatutoryRequirement>> GetStatutoryRequirement(int assetId)
        {
            return await _context.Hdr_StatutoryRequirement.Where(x => x.AssetID == assetId).ToListAsync();
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

        /// <summary>
        /// update assit details when editing
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public async Task<Hdr_Asset> UpdateAsset(Hdr_Asset asset)
        {
            var query = await GetAssetDetailById(asset.ID);
            if (query != null)
            {
                query.AssetTypeID = asset.AssetTypeID;
                query.CategoryID = asset.CategoryID;
                query.EngineNo = asset.EngineNo.ToUpper().Trim();
                query.ChassisNo = asset.ChassisNo.ToUpper().Trim();
                query.Make = asset.Make;
                query.ModelID = asset.ModelID;
                query.EngineCapacity = asset.EngineCapacity;
                query.FuelTypeID = asset.FuelTypeID;
                query.Year = asset.Year;
                query.Color = asset.Color;
                query.AssetValue = asset.AssetValue;
                query.GroupID = asset.GroupID;
                //query.TagNo = string.IsNullOrEmpty(asset.TagNo.Trim()) ? "" : asset.TagNo.Trim();
                //query.Comment = string.IsNullOrEmpty(asset.Comment.Trim()) ? "" : asset.Comment.Trim();
                query.AssetStatus = asset.AssetStatus.Value;

                if (asset.InsuranceExpiryDate != null)
                {
                    query.InsuranceExpiryDate = asset.InsuranceExpiryDate;
                }
                if (asset.RoadTaxExpiryDate != null)
                {
                    query.RoadTaxExpiryDate = asset.RoadTaxExpiryDate;
                }
                if (asset.FitnessExpiryDate != null)
                {
                    query.FitnessExpiryDate = asset.FitnessExpiryDate;
                }
            }

            await _context.SaveChangesAsync();

            return query;
        }

        public async Task OverrideMaintenanceStatus(int assetId, int statusId)
        {
            var query = await GetAssetDetailById(assetId);
            if (query != null)
            {
                query.AssetStatus = statusId;
                await _context.SaveChangesAsync();
            }
        }

        public void UpdateMileage(string regNo, double newMileage)
        {
            var query = _context.Hdr_Asset.FirstOrDefault(x => x.RegNo.Trim().ToUpper() == regNo.Trim().ToUpper());
            if (query != null)
            {
                query.MileageLastService = query.CurrentMileage;
                query.CurrentMileage = newMileage;
                query.LastServiceDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                query.AssetStatus = 4;
                _context.SaveChanges();
            }
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

        public async Task<List<AdmGroupType>> GetGroupType()
        {
            return await _context.AdmGroupType.ToListAsync();
        }
    }
}
