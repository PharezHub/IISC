using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using IISC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages
{
    public class LoginModel : BasePageModel
    {
        private readonly IAccountRepository accountRepository;
        private SecurityManager securityManager = new SecurityManager();
        public string Msg;

        public LoginModel(IAccountRepository accountRepository)
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
            else if(!string.IsNullOrEmpty(username.Trim()))
            {
                var query = await accountRepository.Login(username.Trim());
                if (query.ToList().Count < 1)
                {
                    Msg = "Invalid Login or Access Denied";
                    return Page();
                }
                else
                {
                    //Msg = "Login successfully";
                    await securityManager.SignIn(HttpContext, username.Trim(), query.ToList());
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }
    }
}
