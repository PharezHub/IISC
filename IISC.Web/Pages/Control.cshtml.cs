using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using IISC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages
{
    public class ControlModel : PageModel
    {
        private readonly IAccountRepository accountRepository;
        private SecurityManager securityManager = new SecurityManager();
        public string Msg;

        public ControlModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string username, string password)
        {
            if (string.IsNullOrEmpty(username.Trim()))
            {
                Msg = "Invalid Login or Access Denied";
                return Page();
            }
            else if (!string.IsNullOrEmpty(username))
            {
                //var query = await accountRepository.Login(username);

                if (username.ToUpper() != "control".ToUpper())
                {
                    Msg = "Invalid Login or Access Denied";
                    return Page();
                }
                else
                {
                    //Msg = "Login successfully";
                    List<zRoleUser> query = new List<zRoleUser>()
                    { new zRoleUser { UserId = "control".ToUpper(), ID=1, CreatedOn=DateTime.Now, LoggedBy="control".ToUpper(), RoleName="admin"} };
                    await securityManager.SignIn(HttpContext, username, query.ToList());
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
