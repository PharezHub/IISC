using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class AdmPriority
    {
        [Key]
        public int ID { get; set; }
        public string PriorityName { get; set; }
    }
}
