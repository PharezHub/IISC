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
        Task<IEnumerable<HdrMaintenanceViewModel>> GetMaintenanceByAssetId(int assetId, int statusId);
        Task<IEnumerable<HdrMaintenanceViewModel>> GetMaintenanceById(int Id);
        Task<List<Adm_MaintenanceType>> GetMaintenanceType();
        Task<List<AdmSection>> GetSection();
        Task<List<AdmPriority>> GetPriority();
        Task<List<AdmPurpose>> GetPurpose();
        Task<List<AdmReason>> GetReason();
        Task AddMaintenanceType(Adm_MaintenanceType type);
        void AddPartsUsed(TrnPartUsed partUsed);
        Task UpdatePartUsed(TrnPartUsed partUsed);
        Task<TrnPartUsed> GetPartsUsedById(int partId);
        Task<IEnumerable<PartUsedViewModel>> GetPartsUsed(int maintenanceId);
        Task UpdateMaintenance(int maintenanceId,int statusId, string closureComment, DateTime dateClose, string userName);
        Task<IEnumerable<AdmPartsCatalog>> GetScheduleMaintenanceParts(int categoryId, int makeId, int modelId);

        bool ValidateMaintenance(Adm_MaintenanceType type);
        Task AddWorkOrder(WorkOrderHdr workOrderHdr);

        /// <summary>
        /// Id represents the maintenance id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<WorkOrderHdrViewModel>> GetWorkOrderHdr(int id);
        void AddWOPartsUsed(TrnWorkOrderParts workOrderParts);
        Task<IEnumerable<TrnWorkOrderParts>> GetWorkOrderParts(int id);
        Task AddSpecialTools(TrnSpecialTools specialTools);

        /// <summary>
        /// Id represents maintenance Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<IEnumerable<TrnSpecialTools>> GetSpecialTools(int Id);
    }
}
