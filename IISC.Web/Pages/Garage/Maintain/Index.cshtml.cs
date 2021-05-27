using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class IndexModel : PageModel
    {
        private readonly IAxAutoMobileRepository autoMobileRepository;

        public IndexModel(IAxAutoMobileRepository autoMobileRepository)
        {
            this.autoMobileRepository = autoMobileRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetSearch(string searchItem = "filter")
        {
            var query = await autoMobileRepository.GetAxAutoMobile(searchItem);
            return new JsonResult(query);
        }
    }
}
