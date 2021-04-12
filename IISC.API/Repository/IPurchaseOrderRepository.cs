using API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.API.Repository
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PoDetail>> GetPoDetail(string poNumber, string itemNo);
    }
}
