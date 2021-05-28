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
    public class ManageUserModel : BasePageModel
    {
        private readonly IAccountRepository accountRepository;

        [BindProperty]
        public zUsers Users { get; set; }

        [BindProperty]
        public IEnumerable<zUsers> UsersList { get; set; }

        public ManageUserModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            UsersList = await accountRepository.GetUsers();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Users.CreatedBy = User.Identity.Name;
            Users.CreatedOn = DateTime.Now;
            Users.ID = 0;

            if (!ModelState.IsValid)
            {
                Notify("Enter missing field.", notificationType: Models.NotificationType.error);
                return Page();
            }

            await accountRepository.AddNewUser(Users);
            Notify("User account added successfully");

            UsersList = await accountRepository.GetUsers();
            return Page();
        }
    }
}
