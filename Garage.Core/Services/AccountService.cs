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

        public async Task AddNewUser(zUsers useraccount)
        {
            var query = _context.zUsers.Add(useraccount);
            await _context.SaveChangesAsync();
        }

        public async Task<List<zRoleUser>> FindAccount(string username)
        {
            return await _context.zRoleUser.Where(x => x.UserId == username).ToListAsync();
        }

        public async Task<zUsers> FindAccount(int id)
        {
            return await _context.zUsers.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<zRole>> GetRoles()
        {
            return await _context.zRole.ToListAsync();
        }

        public async Task<IEnumerable<RoleUserViewModel>> GetRoles(string username)
        {
            return await _context.RoleUserViewModel.FromSqlRaw("zspGetRoleUser {0}", username).ToListAsync();
        }

        public async Task<IEnumerable<zUsers>> GetUsers()
        {
            return await _context.zUsers.ToListAsync();
        }

        public async Task<IEnumerable<zRoleUser>> Login(string username)
        {
            var query = await _context.zRoleUser.Where(x => x.UserId == username).ToListAsync();
            return query;
        }
    }
}
