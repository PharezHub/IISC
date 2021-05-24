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
    public class AxAutoMobileService : IAxAutoMobileRepository
    {
        private readonly GarageDbContext _context;

        public AxAutoMobileService(GarageDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<AXAutoMobileViewModel>> GetAxAutoMobile()
        {
            return await _context.AXAutoMobileViewModel.FromSqlRaw("spGetAXAutoMobile").ToListAsync();
        }

        public async Task<IEnumerable<AXAutoMobile>> GetAxAutoMobile(string spareName)
        {
            return await _context.AXAutoMobile.Where(x => x.ItemName.Trim().Contains(spareName)).ToListAsync();
        }

        public async Task<AXAutoMobile> GetAxAutoMobileItem(string itemId)
        {
            return await _context.AXAutoMobile.FirstAsync(x => x.ItemId == itemId);
        }
    }
}
