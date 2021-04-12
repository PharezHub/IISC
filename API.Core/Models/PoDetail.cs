using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Models
{
    public class PoDetail
    {
        public int ID { get; set; }
        public string PurchaseOrder { get; set; }
        public int LineId { get; set; }
        public DateTime PoDate { get; set; }
        public string PoDescription { get; set; }
        public string Stockcode { get; set; }
        public string StockDescription { get; set; }
        public int StockQty { get; set; }
        public float StockCost { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

    }
}
