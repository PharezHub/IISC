using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class WorkOrderHdr
    {
        [Key]
        public int ID { get; set; }
        public int MaintenanceID { get; set; }
        public int SectionID { get; set; }
        public int Priority { get; set; }
        public int Purpose { get; set; }
        public int ReasonForFailure { get; set; }
        public string WorkDescription { get; set; }
        public string LoggedBy { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
