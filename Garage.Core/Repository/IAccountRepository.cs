using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface IAccountRepository
    {
        Task<List<zRoleUser>> FindAccount(string username);
        /// <summary>
        /// Get user information by id instead of username to hide the username from the url.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<zUsers> FindAccount(int id);
        Task<IEnumerable<zRoleUser>> Login(string username);
        Task AddNewUser(zUsers useraccount);
        Task AddRoleUser(zRoleUser roleUser);
        Task<IEnumerable<zUsers>> GetUsers();
        Task<IEnumerable<zRole>> GetRoles();

        /// <summary>
        /// Get roles granted to a user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<IEnumerable<RoleUserViewModel>> GetRoles(string username);
        Task DeleteRole(int roleId);
    }
}
