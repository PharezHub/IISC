using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface ILogSheetRepository
    {
        IEnumerable<LogSheetListViewModel> GetLogSheetList();
    }
}
