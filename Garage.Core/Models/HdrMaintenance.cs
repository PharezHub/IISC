using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Models
{
    public class HdrMaintenance
    {
        public int ID { get; set; }
        public int MaintenanceType { get; set; }
        public string MaintenanceSummary { get; set; }
        public DateTime ServiceDate { get; set; }
        public double CurrentMileage { get; set; }
        public string LoggedBy { get; set; }
        public int StatusID { get; set; }
        public DateTime DateIn { get; set; }
        public string TimeIn { get; set; }
        public DateTime DateClosed { get; set; }
    }
}
