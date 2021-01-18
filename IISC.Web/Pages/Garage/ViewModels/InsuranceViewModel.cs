using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web.Pages.Garage.ViewModels
{
    public class InsuranceViewModel
    {
        public int TypeId { get; set; }
        public string CompanyName { get; set; }
        public double InsuranceValue { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateTo { get; set; }
    }
}
