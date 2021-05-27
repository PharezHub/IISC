using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Spares
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class AXAutomobileModel : PageModel
    {
        private readonly IAxAutoMobileRepository autoMobileRepository;

        public AXAutomobileModel(IAxAutoMobileRepository autoMobileRepository)
        {
            this.autoMobileRepository = autoMobileRepository;
        }

        public IEnumerable<AXAutoMobile> AXAutoMobileList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            AXAutoMobileList = await autoMobileRepository.GetAxAutoMobile("");
            return Page();
        }
    }
}
