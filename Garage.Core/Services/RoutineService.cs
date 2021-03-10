using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Services
{
    public class RoutineService : IRoutineRepository
    {
        private readonly GarageDbContext _context;

        public RoutineService(GarageDbContext context)
        {
            _context = context;
        }

        public void AddLogSheetTrigger(Adm_ManageLogSheet logSheet)
        {
            // Validate existing log trigger
            var query = _context.Adm_ManageLogSheet.FirstOrDefault(x => x.CategoryID == logSheet.CategoryID
                        && x.LogSheetTypeID == logSheet.LogSheetTypeID
                        && x.TriggerFrequency == logSheet.TriggerFrequency);

            if (query != null)
            {
                // Do nothing log type already configure.
                // Show message to user
            }
            else
            {
                _context.Adm_ManageLogSheet.Add(logSheet);
                _context.SaveChanges();
            }
        }

        public void AddManageTrigger(Adm_ManageTrigger trigger)
        {
            var query = _context.Adm_ManageTrigger.FirstOrDefault(x => x.CategoryID == trigger.CategoryID && x.TriggerID == trigger.TriggerID);
            if (query != null)
            {
                // Do not add duplicate triggers
            }
            else
            {
                _context.Adm_ManageTrigger.Add(trigger);
                _context.SaveChanges();
            }
        }

        public void AddTrigger(Adm_TriggerType triggerType)
        {
            _context.Adm_TriggerType.Add(triggerType);
            _context.SaveChanges();
        }

        public void DeleteLogSheetTrigger(int Id)
        {
            try
            {
                var query = _context.Adm_ManageLogSheet.FirstOrDefault(x => x.ID == Id);
                if (query != null)
                {
                    _context.Adm_ManageLogSheet.Remove(query);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Adm_ManageLogSheet> GetAllLogSheetTrigger()
        {
            return _context.Adm_ManageLogSheet.ToList();
        }

        public IEnumerable<Adm_TriggerType> GetAllTriggerTypes()
        {
            return _context.Adm_TriggerType;
        }

        public IEnumerable<Adm_Frequency> GetFrequency()
        {
            return _context.Adm_Frequency.ToList();
        }

        public async Task<IEnumerable<LogSheetSetupViewModel>> GetLogSheetSetup()
        {
            return await _context.LogSheetSetupViewModel.FromSqlRaw("spGetLogSheetSetup").ToListAsync();
        }

        public Adm_ManageLogSheet GetLogSheetTriggerById(int id)
        {
            return _context.Adm_ManageLogSheet.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<MaintenanceTriggerListViewModel> GetMaintenanceTriggerList()
        {
            return _context.MaintenanceTriggerListViewModel.FromSqlRaw("spGetMaintenanceTriggerList").ToList();
        }

        public Adm_ManageTrigger GetManageTriggerById(int Id)
        {
            return _context.Adm_ManageTrigger.FirstOrDefault(x => x.ID == Id);
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
                manageTrigger.MaintenanceTrigger = trigger.MaintenanceTrigger;
                _context.SaveChanges();
            }
        }

        public void UpdateTrigger(Adm_TriggerType triggerType)
        {
            var trigger = _context.Adm_TriggerType.Attach(triggerType);
            trigger.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool ValidateManageTrigger(Adm_ManageTrigger manageTrigger)
        {
            bool result = false;
            Adm_ManageTrigger trigger = _context.Adm_ManageTrigger.
                FirstOrDefault(x => x.CategoryID == manageTrigger.CategoryID && x.TriggerID == manageTrigger.TriggerID);
            if (trigger != null)
            {
                result = true;
            }
            return result;
        }

        public bool ValidateTrigger(Adm_TriggerType trigger)
        {
            bool result = false;
            Adm_TriggerType triggerType = _context.Adm_TriggerType.
                FirstOrDefault(x => x.TriggerName.ToUpper() == trigger.TriggerName.ToUpper());
            if (triggerType != null)
            {
                result = true;
            }
            return result;
        }
    }
}
