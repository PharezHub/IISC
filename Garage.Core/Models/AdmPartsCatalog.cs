using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class AdmPartsCatalog
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        public string PartNumber { get; set; }
        public int CategoryID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string Comment { get; set; }
    }
}
