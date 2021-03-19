using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface IDashboardRepository
    {
        Task<int> GetMaintenanceCounts(int assetId, int typeId);
    }
}
