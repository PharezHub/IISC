using API.Core.Models;
using API.Core.APIContext;
using IISC.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IISC.API.Services
{
    public class PurchaseOrderService : IPurchaseOrderRepository
    {
        private readonly APIDbContext context;

        public PurchaseOrderService(APIDbContext context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// Get ERP purchase order details using the purchase order number and item number.
        /// </summary>
        /// <param name="poNumber"></param>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PoDetail>> GetPoDetail(string poNumber, string itemNumber)
        {
            return await context.PoDetail.FromSqlRaw("GMS_GetItemCost {0},{1}", poNumber, itemNumber).ToListAsync();
        }
    }
}
