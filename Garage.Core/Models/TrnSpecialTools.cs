using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnSpecialTools
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MaintenanceID { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Special instructions is a requred")]
        public string SpecialInstructions { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
