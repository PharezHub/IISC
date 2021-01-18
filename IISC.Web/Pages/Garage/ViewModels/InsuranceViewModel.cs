using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web.Pages.Garage.ViewModels
{
    public class InsuranceViewModel
    {
        public int TypeId { get; set; }
        public string CompanyName { get; set; }
        public double InsuranceValue { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
