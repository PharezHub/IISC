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

        public async Task<MaintenanceTags> GetMaintenanceCounts(int assetId, int typeId)
        {
            return await _context.MaintenanceTags.FromSqlRaw("spGetTags {0},{1}", assetId, typeId).FirstOrDefaultAsync();
        }
    }
}
