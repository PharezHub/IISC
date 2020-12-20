using Garage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface IRoutineRepository
    {
        // Manage add trigger
        void AddTrigger(Adm_TriggerType triggerType);
        IEnumerable<Adm_TriggerType> GetAllTriggerTypes();
        Adm_TriggerType GetTriggerById(int id);
    }
}
