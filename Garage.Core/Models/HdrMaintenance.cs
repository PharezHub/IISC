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

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BreakdownDate { get; set; }
        [Required]
        public double? CurrentMileage { get; set; }
        public string LoggedBy { get; set; }
        public int StatusID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeIn { get; set; }
        public string TimeIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateClosed { get; set; }
        public string RegNo { get; set; }
        public int AssetID { get; set; }
        public string ClosureComment { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
