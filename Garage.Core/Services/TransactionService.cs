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
                _context.Database.ExecuteSqlRaw("spAddPartsUsed {0},{1},{2},{3},{4},{5},{6},{7}"
                    , partUsed.MainID, partUsed.ProblemDescription, partUsed.DocketNo, partUsed.PartID, partUsed.Qty, partUsed.PartCost, partUsed.PurchaseOrder, partUsed.LoggedBy);
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

        public IEnumerable<HdrMaintenanceViewModel> GetMaintenanceById(int Id)
        {
            return _context.HdrMaintenanceViewModel.FromSqlRaw("GetMaintenanceById {0}", Id).ToList();
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
            }
            catch (Exception)
            {

                throw;
            }

            var query = _context.HdrMaintenance.FirstOrDefault(x => x.ID == maintenanceId);
            if (query != null)
            {
                query.StatusID = 1;
                query.ModifiedOn = DateTime.Now;
                query.ClosureComment = closureComment.Trim();
                query.ModifiedBy = userName;
                query.DateClosed = dateClose;

                await _context.SaveChangesAsync();
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

        public Task<IEnumerable<TrnWorkOrderParts>> GetWorkOrderParts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
