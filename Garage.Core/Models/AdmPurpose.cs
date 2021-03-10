using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class AdmPurpose
    {
        [Key]
        public int ID { get; set; }
        public string PurposeDescription { get; set; }
    }
}
