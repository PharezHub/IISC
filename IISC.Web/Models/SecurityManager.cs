using Garage.Core.Models;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IISC.Web.Models
{
    public class SecurityManager
    {
        public async Task SignIn(HttpContext httpContext, string username, List<zRoleUser> roleList)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            identity.AddClaim(new Claim(ClaimTypes.Name, username));
            identity.AddClaims(getUserClaims(roleList, username));
            var principal = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = false });
        }

        public void SignOut(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> getUserClaims(List<zRoleUser> rolesList, string username)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            foreach (var role in rolesList)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }
            return claims;
        }
    }
}
