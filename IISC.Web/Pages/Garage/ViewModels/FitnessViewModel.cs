using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web.Pages.Garage.ViewModels
{
    public class FitnessViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateRenewed { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
    }
}
