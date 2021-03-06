﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class WorkOrderHdr
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Maintenance Id is required")]
        public int MaintenanceID { get; set; }
        [Required(ErrorMessage = "Section is required")]
        public int SectionID { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public int Priority { get; set; }
        [Required(ErrorMessage = "Purpose is required")]
        public int Purpose { get; set; }
        [Required(ErrorMessage = "Reason for failure is required")]
        public int ReasonForFailure { get; set; }
        [Required(ErrorMessage = "Work description is required")]
        public string WorkDescription { get; set; }
        public string LoggedBy { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
