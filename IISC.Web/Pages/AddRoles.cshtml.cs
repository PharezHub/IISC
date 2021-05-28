using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages
{
    [Authorize(Roles = "admin")]
    public class AddRolesModel : PageModel
    {
        private readonly IAccountRepository accountRepository;

        [BindProperty]
        public IEnumerable<RoleUserViewModel> UserRoleList { get; set; }

        [BindProperty]
        public zUsers Users { get; set; }

        [BindProperty]
        public zRoleUser RoleUser { get; set; }

        public AddRolesModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Users = await accountRepository.FindAccount(id);
            UserRoleList = await accountRepository.GetRoles(Users.UserId);
            return Page();
        }
    }
}
