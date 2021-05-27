using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage
{
    [Authorize(Roles = "admin,user,asset,fuel,maintenance,utilization")]
    public class IndexModel : PageModel
    {
        private readonly INavigationRepository navigationRepository;

        public IndexModel(INavigationRepository navigationRepository)
        {
            this.navigationRepository = navigationRepository;
        }

        [BindProperty]
        public IEnumerable<Gen_SystemArea> SystemAreaList { get; set; }

        public void OnGet()
        {
            SystemAreaList = navigationRepository.GetGarageSystemArea();
        }
    }
}
