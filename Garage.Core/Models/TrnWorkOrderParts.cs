using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnWorkOrderParts
    {
        [Key]
        public int ID { get; set; }
        public int MaintenanceID { get; set; }
        public int PartID { get; set; }
        public string PartDescription { get; set; }
        public int Qty { get; set; }
        public float UnitCost { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
