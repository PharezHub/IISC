using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnSpecialTools
    {
        [Key]
        public int ID { get; set; }
        public int MaintenanceID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string SpecialInstructions { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
