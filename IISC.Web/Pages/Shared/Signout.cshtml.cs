using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IISC.Web.Pages.Shared
{
    public class SignoutModel : PageModel
    {
        private readonly ILogger<SignoutModel> _logger;
        private SecurityManager securityManager = new SecurityManager();

        public SignoutModel(ILogger<SignoutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            _logger.LogInformation($"SIIS Log - SIGN-OUT - {HttpContext.User} - {HttpContext}");
            return RedirectToPage("/AccessDenied");
        }
    }
}
