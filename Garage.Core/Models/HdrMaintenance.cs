using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class HdrMaintenance
    {
        [Key]
        public int ID { get; set; }
        public int MaintenanceType { get; set; }
        [Required]
        public string MaintenanceSummary { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ServiceDate { get; set; }
        [Required]
        public double? CurrentMileage { get; set; }
        public string LoggedBy { get; set; }
        public int StatusID { get; set; }
        public DateTime DateIn { get; set; }
        public string TimeIn { get; set; }
        public DateTime? DateClosed { get; set; }
        public string RegNo { get; set; }
        public int AssetID { get; set; }

    }
}
