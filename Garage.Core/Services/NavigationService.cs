using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Services
{
    public class NavigationService : INavigationRepository
    {
        private readonly GarageDbContext context;

        public NavigationService(GarageDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Gen_SystemArea> GetGarageSystemArea()
        {
            return context.Gen_SystemArea;
        }
    }
}
