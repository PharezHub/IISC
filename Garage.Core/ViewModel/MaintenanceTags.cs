using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class MaintenanceTags
    {
        [Key]
        public int maintenanceCount { get; set; }
    }
}
