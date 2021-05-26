using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly GarageDbContext _context;

        public AccountService(GarageDbContext context)
        {
            _context = context;
        }

        public async Task<AccountViewModel> FindAccount(string username)
        {
            AccountViewModel useracc = new AccountViewModel();
            var query = await _context.zRoleUser.Where(x => x.UserId == username).ToListAsync();
            if (query != null)
            {
                useracc.Username = username;
                int _pos = 0;
                foreach (var item in query)
                {
                    useracc.Roles[_pos] = item.RoleName;
                    _pos++;
                }
            }

            return useracc;
        }

        public async Task<zRoleUser> Login(string username)
        {
            return await _context.zRoleUser.FirstAsync(x => x.UserId == username);
        }
    }
}
