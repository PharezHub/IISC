using IISC.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISC.Web.Pages
{
    [Authorize(Roles = "admin,user")]
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //private SecurityManager securityManager = new SecurityManager();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation($"SIIS Welcome - {HttpContext.User} - {User.Identity.Name} - {User.Claims}");

            return Page();
        }

        //public IActionResult OnGetLogout()
        //{
        //    securityManager.SignOut(HttpContext);
        //    _logger.LogInformation($"SIIS Log - SIGN-OUT - {HttpContext.User} - {HttpContext}");
        //    return RedirectToPage("/AccessDenied");
        //}
    }
}
