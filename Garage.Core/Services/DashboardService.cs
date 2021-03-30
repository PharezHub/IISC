using Garage.Core.AppDbContext;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Services
{
    public class DashboardService : IDashboardRepository
    {
        private readonly GarageDbContext _context;

        public DashboardService(GarageDbContext context)
        {
            this._context = context;
        }

        public async Task<int> GetMaintenanceCounts(int assetId, int typeId)
        {
            int resultValue = 0;
            //return await _context.MaintenanceTags.FromSqlRaw("spGetTags {0},{1}", assetId, typeId).FirstOrDefaultAsync();
            if (typeId == 0)
            {
                //TODO: All Maintenance
                var totalMaintenance = await _context.HdrMaintenance.CountAsync(x => x.AssetID == assetId);
                resultValue = totalMaintenance;
            }
            else if (typeId == 1)
            {
                //TODO: Breakdown
                var totalMaintenance = await _context.HdrMaintenance.CountAsync(x => x.AssetID == assetId && x.MaintenanceType == typeId);
                resultValue = totalMaintenance;
            }
            else if (typeId == 2)
            {
                //TODO: Scheduled
                var totalMaintenance = await _context.HdrMaintenance.CountAsync(x => x.AssetID == assetId && x.MaintenanceType == typeId);
                resultValue = totalMaintenance;
            }
            else if (typeId == 3)
            {
                //TODO: Active Breakdown
                var totalMaintenance = await _context.HdrMaintenance.CountAsync(x => x.AssetID == assetId && x.MaintenanceType == 1 && x.StatusID == 0);
                resultValue = totalMaintenance;
            }
            return resultValue;
        }

    }
}
