using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class HdrMaintenanceViewModel
    {
        public int ID { get; set; }
        public int MaintenanceType { get; set; }
        public string MaintenanceName { get; set; }
        public string MaintenanceSummary { get; set; }
        [DataType(DataType.Date)]
        public DateTime BreakdownDate { get; set; }
        public double? CurrentMileage { get; set; }
        public string LoggedBy { get; set; }
        public int StatusID { get; set; }
        public string TransStatus { get; set; }
        public DateTime DateTimeIn { get; set; }
        public string TimeIn { get; set; }
        public DateTime? DateClosed { get; set; }
        public string RegNo { get; set; }
        public int AssetID { get; set; }
        public string ClosureComment { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
