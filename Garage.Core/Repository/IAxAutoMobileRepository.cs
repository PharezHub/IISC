using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface IAxAutoMobileRepository
    {
        Task<IEnumerable<AXAutoMobileViewModel>> GetAxAutoMobile();
        Task<IEnumerable<AXAutoMobile>> GetAxAutoMobile(string spareName);
        Task<AXAutoMobile> GetAxAutoMobileItem(string itemId);
    }
}
