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
        Task<IEnumerable<zRoleUser>> Login(string username);
        Task AddNewUser(zUsers useraccount);
        Task<IEnumerable<zUsers>> GetUsers();
        Task<IEnumerable<zRole>> GetRoles();
    }
}
