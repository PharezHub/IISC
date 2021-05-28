using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using IISC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IISC.Web.Pages
{
    public class LoginModel : BasePageModel
    {
        private readonly IAccountRepository accountRepository;
        private readonly ILogger<LoginModel> _logger;
        private SecurityManager securityManager = new SecurityManager();
        public string Msg;

        public LoginModel(IAccountRepository accountRepository, ILogger<LoginModel> logger)
        {
            this.accountRepository = accountRepository;
            this._logger = logger;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(string password)
        {
            string username = User.Identity.Name;
            if (string.IsNullOrEmpty(username.Trim()))
            {
                Msg = "Invalid Login or Access Denied";
                _logger.LogInformation($"SIIS Log - {Msg} - {username}");
                return Page();
            }
            else if(!string.IsNullOrEmpty(username))
            {
                var query = await accountRepository.Login(username);
                if (query.ToList().Count < 1)
                {
                    Msg = "Invalid Login or Access Denied";
                    _logger.LogInformation($"SIIS Log - {Msg} - {username} - Roles - {query.ToList().Count}");
                    return Page();
                }
                else
                {
                    //Msg = "Login successfully";
                    await securityManager.SignIn(HttpContext, username, query.ToList());
                    _logger.LogInformation($"SIIS Log - Login was successful  - {username}");
                    return RedirectToPage("Index");
                }
            }
            _logger.LogInformation($"SIIS Log - could not login ERROR  - {username}");
            return Page();
        }
                
    }
}
