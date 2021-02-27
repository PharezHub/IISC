using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnPartUsed
    {
        [Key]
        public int ID { get; set; }
        public int MainID { get; set; }

        [Required(ErrorMessage = "Problem description is required")]
        public string ProblemDescription { get; set; }

        [Required(ErrorMessage = "Docket number is required")]
        public string DocketNo { get; set; }
        public int PartID { get; set; }
        public int Qty { get; set; }
        public float? PartCost { get; set; }
        public string PurchaseOrder { get; set; }
        public DateTime DateLogged { get; set; }
        public string LoggedBy { get; set; }
    }
}
