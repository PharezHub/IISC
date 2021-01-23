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
    public class LogSheetService : ILogSheetRepository
    {
        private readonly GarageDbContext _context;

        public LogSheetService(GarageDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Trn_LogSheet> GetLogHistory(string regNo)
        {
            return _context.Trn_LogSheet.Where(x => x.RegNo == regNo).ToList();
        }

        public IEnumerable<LogSheetListViewModel> GetLogSheetById(int id)
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetById {0}", id).ToList();
        }

        public IEnumerable<LogSheetListViewModel> GetLogSheetList(int statusId)
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetList {0}", statusId).ToList();
        }

        public void UpdateLogSheet(LogSheetListViewModel logSheet)
        {
            var query = _context.Trn_LogSheet.FirstOrDefault(x => x.ID == logSheet.ID);
            if (query != null)
            {
                _context.Database.ExecuteSqlRaw("spUpdateLogSheet {0},{1},{2},{3},{4},{5}", logSheet.ID, logSheet.CurrentValue, 1, DateTime.Now,
                    logSheet.ModifiedBy, logSheet.LogTypeID);
                //query.LogStatus = 1;
                //query.CurrentValue = logSheet.CurrentValue;
                //query.ModifiedOn = DateTime.Now;
                //query.ModifiedBy = logSheet.ModifiedBy;

                //_context.SaveChanges();
            }
        }
    }
}
