﻿using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface ILogSheetRepository
    {
        IEnumerable<LogSheetListViewModel> GetLogSheetList(int statusId);
        IEnumerable<LogSheetListViewModel> GetLogSheetById(int id);
        IEnumerable<Trn_LogSheet> GetLogHistory(string regNo);
        void UpdateLogSheet(LogSheetListViewModel logSheet);
        void AddLogSheet(int categoryId, double currentValue, string regNo, string comment);
    }
}