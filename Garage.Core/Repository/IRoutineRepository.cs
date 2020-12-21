using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface IRoutineRepository
    {
        // Manage add trigger
        void AddTrigger(Adm_TriggerType triggerType);
        void AddManageTrigger(Adm_ManageTrigger trigger);

        IEnumerable<Adm_TriggerType> GetAllTriggerTypes();
        Adm_TriggerType GetTriggerById(int id);
        IEnumerable<MaintenanceTriggerListViewModel> GetMaintenanceTriggerList();
    }
}
