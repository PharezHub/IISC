using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface ITransaction
    {
        Task<HdrMaintenance> AddMaintenance(HdrMaintenance hdr);
        Task<IEnumerable<HdrMaintenanceViewModel>> GetMaintenanceByAssetId(int assetId);
        IEnumerable<HdrMaintenanceViewModel> GetMaintenanceById(int Id);
        Task<List<Adm_MaintenanceType>> GetMaintenanceType();
    }
}
