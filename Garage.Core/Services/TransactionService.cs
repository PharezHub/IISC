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
    }
}
