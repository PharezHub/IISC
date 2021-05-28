using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages
{
    [Authorize(Roles = "admin")]
    public class ManageRolesModel : PageModel
    {
        private readonly IAccountRepository accountRepository;
        public IEnumerable<zRole> RoleList { get; set; }

        public ManageRolesModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            RoleList = await accountRepository.GetRoles();
            return Page();
        }
    }
}
