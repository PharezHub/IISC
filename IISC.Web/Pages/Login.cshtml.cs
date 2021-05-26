using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages
{
    public class LoginModel : BasePageModel
    {
        private readonly IAccountRepository accountRepository;

        public LoginModel(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string username, string password)
        {
            if (string.IsNullOrEmpty(username.Trim()) || await accountRepository.Login(username.Trim()) == null)
            {
                Notify("Invalid Login or Access Denied", notificationType:Models.NotificationType.warning);
                return Page();
            }
            return Page();
        }
    }
}
