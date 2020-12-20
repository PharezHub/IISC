using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
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

        public void AddTrigger(Adm_TriggerType triggerType)
        {
            _context.Adm_TriggerType.Add(triggerType);
            _context.SaveChanges();
        }

        public IEnumerable<Adm_TriggerType> GetAllTriggerTypes()
        {
            return _context.Adm_TriggerType;
        }

        public Adm_TriggerType GetTriggerById(int id)
        {
            return _context.Adm_TriggerType.FirstOrDefault(x => x.ID == id);
        }
    }
}
