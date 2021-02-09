using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web.Pages.Garage.ViewModels
{
    public class InsuranceViewModel
    {
        public int TypeId { get; set; }

        [Required(ErrorMessage ="Insurance company is required")]
        public string CompanyName { get; set; }
        public double InsuranceValue { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insurance start date is required")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insurance end date is required")]
        public DateTime DateTo { get; set; }
    }
}
