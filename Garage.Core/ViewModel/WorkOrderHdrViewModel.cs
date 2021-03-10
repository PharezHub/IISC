using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class WorkOrderHdrViewModel
    {
        public int ID { get; set; }
        public int MaintenanceID { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int Priority { get; set; }
        public string PriorityName { get; set; }
        public int Purpose { get; set; }
        public string PurposeDescription { get; set; }
        public int ReasonForFailure { get; set; }
        public string ReasonOfFailure { get; set; }
        public string WorkDescription { get; set; }
        public string LoggedBy { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
