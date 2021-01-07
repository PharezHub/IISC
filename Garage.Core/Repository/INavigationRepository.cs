using Garage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface INavigationRepository
    {
        IEnumerable<Gen_SystemArea> GetGarageSystemArea();
    }
}
