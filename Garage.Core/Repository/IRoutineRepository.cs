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
        void UpdateManageTrigger(Adm_ManageTrigger trigger);
        public Adm_ManageTrigger GetManageTriggerById(int id);

        IEnumerable<Adm_TriggerType> GetAllTriggerTypes();

        Adm_TriggerType GetTriggerById(int id);

        void UpdateTrigger(Adm_TriggerType triggerType);

        IEnumerable<MaintenanceTriggerListViewModel> GetMaintenanceTriggerList();

        IEnumerable<Adm_Frequency> GetFrequency();

        void AddLogSheetTrigger(Adm_ManageLogSheet logSheet);

        IEnumerable<Adm_ManageLogSheet> GetAllLogSheetTrigger();

        Adm_ManageLogSheet GetLogSheetTriggerById(int id);
    }
}
