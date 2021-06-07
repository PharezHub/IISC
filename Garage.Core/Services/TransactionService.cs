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
    public class TransactionService : ITransaction
    {
        private readonly GarageDbContext _context;

        public TransactionService(GarageDbContext context)
        {
            this._context = context;
        }

        public async Task<HdrMaintenance> AddMaintenance(HdrMaintenance hdr)
        {
            try
            {
                _context.HdrMaintenance.Add(hdr);
                await _context.SaveChangesAsync();

                return hdr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddMaintenanceType(Adm_MaintenanceType type)
        {
            if (type != null)
            {
                var query = _context.Adm_MaintenanceType.FirstOrDefault(x => x.MaintenanceName.ToUpper() == type.MaintenanceName.ToUpper());
                if (query != null)
                {
                    _context.Adm_MaintenanceType.Add(type);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public void AddPartsUsed(TrnPartUsed partUsed)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("spAddPartsUsed {0},{1},{2},{3},{4},{5},{6},{7},{8}"
                    , partUsed.MainID, partUsed.ProblemDescription, partUsed.DocketNo, partUsed.PartID, partUsed.Qty, partUsed.PartCost, partUsed.PurchaseOrder, partUsed.LoggedBy, partUsed.IsDeleted);
                //_context.TrnPartUsed.Add(partUsed);
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddWorkOrder(WorkOrderHdr workOrderHdr)
        {
            try
            {
                if (workOrderHdr != null)
                {
                    _context.WorkOrderHdr.Add(workOrderHdr);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<HdrMaintenanceViewModel>> GetMaintenanceByAssetId(int assetId)
        {
            return await _context.HdrMaintenanceViewModel.FromSqlRaw("GetMaintenanceByRegNo {0}", assetId).ToListAsync();
        }

        public async Task<HdrMaintenanceViewModel> GetMaintenanceById(int Id)
        {
            var query = await _context.HdrMaintenanceViewModel.FromSqlRaw("GetMaintenanceById {0}", Id).ToListAsync();
            return query.FirstOrDefault();
        }

        //public async Task<HdrMaintenance> GetMaintenanceById(int assetId)
        //{
        //    try
        //    {
        //        return await _context.HdrMaintenance.FirstOrDefaultAsync(x => x.AssetID == assetId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<List<Adm_MaintenanceType>> GetMaintenanceType()
        {
            return await _context.Adm_MaintenanceType.ToListAsync();
        }

        public async Task<IEnumerable<PartUsedViewModel>> GetPartsUsed(int maintenanceId)
        {
            return await _context.PartUsedViewModel.FromSqlRaw("spGetPartsUsed {0}", maintenanceId).ToListAsync();
        }

        public async  Task<List<AdmPriority>> GetPriority()
        {
            return await _context.AdmPriority.ToListAsync();
        }

        public async Task<List<AdmPurpose>> GetPurpose()
        {
            return await _context.AdmPurpose.ToListAsync();
        }

        public async Task<List<AdmReason>> GetReason()
        {
            return await _context.AdmReason.ToListAsync();
        }

        public async Task<IEnumerable<AdmPartsCatalog>> GetScheduleMaintenanceParts(int categoryId, int makeId, int modelId)
        {
            return await _context.AdmPartsCatalog
                .Where(x => x.CategoryID == categoryId && x.MakeID == makeId && x.ModelID == modelId && x.IsDeleted == false && x.MaintenancePart == true)
                .ToListAsync();
        }

        public async Task<List<AdmSection>> GetSection()
        {
            return await _context.AdmSection.ToListAsync();
        }

        public async Task UpdateMaintenance(int maintenanceId,int statusId, string closureComment,DateTime dateClose, string userName)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("spUpdateMaintenance {0},{1},{2},{3},{4}", maintenanceId, statusId, closureComment, dateClose, userName);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidateMaintenance(Adm_MaintenanceType type)
        {
            bool result = false;
            Adm_MaintenanceType MaintenanceType  = _context.Adm_MaintenanceType.
                FirstOrDefault(x => x.MaintenanceName.Trim().ToUpper() == type.MaintenanceName.Trim().ToUpper());
            if (MaintenanceType != null)
            {
                result = true;
            }
            return result;
        }

        public async Task<IEnumerable<WorkOrderHdrViewModel>> GetWorkOrderHdr(int id)
        {
            return await _context.WorkOrderHdrViewModel.FromSqlRaw("spGetWorkOrderHdr {0}", id).ToListAsync();
        }

        public void AddWOPartsUsed(TrnWorkOrderParts workOrderParts)
        {
            try
            {
                 _context.Database.ExecuteSqlRaw("spAddWOPartsUsed {0},{1},{2},{3},{4}", workOrderParts.MaintenanceID, workOrderParts.PartID, workOrderParts.PartDescription,
                    workOrderParts.Qty, workOrderParts.UnitCost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TrnWorkOrderParts>> GetWorkOrderParts(int id)
        {
            return await _context.TrnWorkOrderParts.FromSqlRaw("spGetWorkOrderParts {0}", id).ToListAsync();
        }

        public async Task AddSpecialTools(TrnSpecialTools specialTools)
        {
            try
            {
                if (specialTools != null)
                {
                    _context.TrnSpecialTools.Add(specialTools);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TrnSpecialTools>> GetSpecialTools(int Id)
        {
            return await _context.TrnSpecialTools.Where(x => x.MaintenanceID == Id).ToListAsync();
        }

        public async Task<TrnPartUsed> GetPartsUsedById(int partId)
        {
            return await _context.TrnPartUsed.FirstOrDefaultAsync(x => x.ID == partId);
        }

        public async Task UpdatePartUsed(TrnPartUsed partUsed)
        {
            try
            {
                //TODO: Update purchase order and price for parts used
                if (partUsed != null)
                {
                    var query = await GetPartsUsedById(partUsed.ID);
                    query.PurchaseOrder = partUsed.PurchaseOrder.Trim();
                    query.PartCost = partUsed.PartCost;

                     await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<HdrMaintenanceViewModel>> GetMaintenanceByAssetId(int assetId, int statusId)
        {
            return await _context.HdrMaintenanceViewModel.FromSqlRaw("GetMaintenanceAssetIdStatus {0},{1}", assetId, statusId).ToListAsync();
        }

        public async Task UpdateMaintenance(HdrMaintenance hdr)
        {
            try
            {
                if (hdr != null)
                {
                    var query = await _context.HdrMaintenance.FirstOrDefaultAsync(x => x.ID == hdr.ID);
                    if (query != null)
                    {
                        query.BreakdownDate = hdr.BreakdownDate;
                        query.DateTimeIn = hdr.DateTimeIn;
                        query.MaintenanceSummary = hdr.MaintenanceSummary.Trim();
                        
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Flag part used as deleted.
        /// </summary>
        /// <param name="deleteId"></param>
        /// <returns></returns>
        public async Task DeletePartUsed(int deleteId)
        {
            try
            {
                if (deleteId > 0)
                {
                    var query = await _context.TrnPartUsed.FindAsync(deleteId);
                    if (query != null)
                    {
                        query.IsDeleted = true;

                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task IncreasePartUsed(int itemId)
        {
            try
            {
                if (itemId > 0)
                {
                    var query = await _context.TrnPartUsed.FindAsync(itemId);
                    if (query != null)
                    {
                        query.Qty +=1;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DecreasePartUsed(int itemId)
        {
            try
            {
                if (itemId > 0)
                {
                    var query = await _context.TrnPartUsed.FindAsync(itemId);
                    if (query != null)
                    {
                        if (query.Qty > 1)
                        {
                            query.Qty -= 1;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
