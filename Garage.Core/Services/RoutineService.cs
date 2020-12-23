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
    public class RoutineService : IRoutineRepository
    {
        private readonly GarageDbContext _context;

        public RoutineService(GarageDbContext context)
        {
            _context = context;
        }

        public void AddManageTrigger(Adm_ManageTrigger trigger)
        {
            _context.Adm_ManageTrigger.Add(trigger);
            _context.SaveChanges();
        }

        public void AddTrigger(Adm_TriggerType triggerType)
        {
            _context.Adm_TriggerType.Add(triggerType);
            _context.SaveChanges();
        }

        public IEnumerable<Adm_TriggerType> GetAllTriggerTypes()
        {
            return _context.Adm_TriggerType;
        }

        public IEnumerable<MaintenanceTriggerListViewModel> GetMaintenanceTriggerList()
        {
            return _context.MaintenanceTriggerListViewModels.FromSqlRaw("spGetMaintenanceTriggerList").ToList();
        }

        public Adm_ManageTrigger GetManageTriggerById(int id)
        {
            return _context.Adm_ManageTrigger.FirstOrDefault(x => x.ID == id);
        }

        public Adm_TriggerType GetTriggerById(int id)
        {
            return _context.Adm_TriggerType.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateManageTrigger(Adm_ManageTrigger trigger)
        {
            var manageTrigger = _context.Adm_ManageTrigger.FirstOrDefault(x => x.ID == trigger.ID);
            if (manageTrigger != null)
            {
                manageTrigger.CategoryID = trigger.CategoryID;
                manageTrigger.TriggerID = trigger.TriggerID;
                manageTrigger.TriggerValue = trigger.TriggerValue;
                manageTrigger.Threshold = trigger.Threshold;
                manageTrigger.ModifiedBy = trigger.ModifiedBy;
                manageTrigger.ModifiedOn = DateTime.Now;

                _context.SaveChanges();
            }
        }

        public void UpdateTrigger(Adm_TriggerType triggerType)
        {
            var trigger = _context.Adm_TriggerType.Attach(triggerType);
            trigger.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
