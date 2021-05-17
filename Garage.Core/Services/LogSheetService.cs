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
    public class LogSheetService : ILogSheetRepository
    {
        private readonly GarageDbContext _context;

        public LogSheetService(GarageDbContext context)
        {
            this._context = context;
        }

        public async Task AddFuelConsumption(TrnFuelConsumption consumption)
        {
            try
            {
                _context.TrnFuelConsumption.Add(consumption);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddLogSheet(int categoryId, double currentValue, string regNo, string comment)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("spAddLogSheet {0},{1},{2},{3}", categoryId, currentValue, regNo, comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<double> GetCurrentFuelPrice(int fuelId)
        {
            return await _context.TrnFuelPriceHistory
                .Where(x => x.FuelID == fuelId)
                .OrderByDescending(x => x.DateLogged)
                .Select(y => y.CurrentPrice)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TrnFuelConsumption>> GetFuelConsumption(string regNumber, int assetId)
        {
            return await _context.TrnFuelConsumption.Where(x => x.RegNo == regNumber && x.AssetID == assetId).ToListAsync();
        }

        public IEnumerable<Trn_LogSheet> GetLogHistory(string regNo)
        {
            return _context.Trn_LogSheet.Where(x => x.RegNo == regNo).Take(15).ToList();
        }

        public IEnumerable<LogSheetListViewModel> GetLogSheetById(int id)
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetById {0}", id).ToList();
        }

        public IEnumerable<LogSheetListViewModel> GetLogSheetList(int statusId)
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetList {0}", statusId).ToList();
        }

        public async Task<double> GetPreviousReading(string regNumber)
        {
            return await _context.TrnFuelConsumption
                .Where(x => x.RegNo == regNumber)
                .OrderByDescending(x => x.TransactionDate)
                .Select(y => y.OdometerReading)
                .FirstOrDefaultAsync();
        }

        public void UpdateLogSheet(LogSheetListViewModel logSheet)
        {
            var query = _context.Trn_LogSheet.FirstOrDefault(x => x.ID == logSheet.ID);
            if (query != null)
            {
                _context.Database.ExecuteSqlRaw("spUpdateLogSheet {0},{1},{2},{3},{4},{5},{6}", logSheet.ID, logSheet.CurrentValue, 1, DateTime.Now,
                    logSheet.ModifiedBy, logSheet.LogTypeID, logSheet.Comment.Trim());
                //query.LogStatus = 1;
                //query.CurrentValue = logSheet.CurrentValue;
                //query.ModifiedOn = DateTime.Now;
                //query.ModifiedBy = logSheet.ModifiedBy;

                //_context.SaveChanges();
            }
        }
    }
}
