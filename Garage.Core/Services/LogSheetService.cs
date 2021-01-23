using Garage.Core.AppDbContext;
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

        public IEnumerable<LogSheetListViewModel> GetLogSheetById(int id)
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetById {0}", id).ToList();
        }

        public IEnumerable<LogSheetListViewModel> GetLogSheetList()
        {
            return _context.LogSheetListViewModel.FromSqlRaw("spGetLogSheetList").ToList();
        }
    }
}
