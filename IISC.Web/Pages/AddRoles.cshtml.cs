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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages
{
    [Authorize(Roles = "admin")]
    public class AddRolesModel : BasePageModel
    {
        private readonly IAccountRepository accountRepository;

        [BindProperty]
        public IEnumerable<RoleUserViewModel> UserRoleList { get; set; }

        public SelectList RolesList { get; set; }

        [BindProperty]
        public zUsers Users { get; set; }

        [BindProperty]
        public zRoleUser RoleUser { get; set; }

        public AddRolesModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            RoleUser = new zRoleUser();
            Users = new zUsers();
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Users = await accountRepository.FindAccount(id);
            UserRoleList = await accountRepository.GetRoles(Users.UserId);
            RolesList = new SelectList(await accountRepository.GetRoles(), nameof(zRole.RoleName), nameof(zRole.RoleName));

            RoleUser.UserId = Users.UserId;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            int Id = Users.ID;
            RoleUser.LoggedBy = User.Identity.Name;
            RoleUser.CreatedOn = DateTime.Now;
            RoleUser.ID = 0;
            Users = await accountRepository.FindAccount(Id);

            //if (!ModelState.IsValid)
            //{
            //    Notify("Enter missing field.", notificationType: Models.NotificationType.error);
            //    return Page();
            //}

            await accountRepository.AddRoleUser(RoleUser);

            Users = await accountRepository.FindAccount(Id);
            UserRoleList = await accountRepository.GetRoles(Users.UserId);
            RolesList = new SelectList(await accountRepository.GetRoles(), nameof(zRole.RoleName), nameof(zRole.RoleName));

            Notify("Role added successfully");

            return RedirectToPage("AddRoles", new { id = Id });
        }

        public async Task<IActionResult> OnGetDeleteRole(int id)
        {
            if (id > 0)
            {
                await accountRepository.DeleteRole(id);
            }
            Notify("Role Deleted successfully", notificationType:Models.NotificationType.info);
            return RedirectToPage("ManageUser");
        }
    }
}
