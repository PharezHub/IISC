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
        Task <AccountViewModel> FindAccount(string username);
        Task<zRoleUser> Login(string username);
    }
}
