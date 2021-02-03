using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Maintain
{
    public class UnplannedModel : PageModel
    {
        public UnplannedModel()
        {

        }

        public HdrMaintenance HdrMaintenance { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }
    }
}
