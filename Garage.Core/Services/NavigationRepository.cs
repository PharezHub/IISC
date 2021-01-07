using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Services
{
    public class NavigationRepository : INavigationRepository
    {
        private readonly GarageDbContext context;

        public NavigationRepository(GarageDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Gen_SystemArea> GetGarageSystemArea()
        {
            return context.Gen_SystemArea;
        }
    }
}
