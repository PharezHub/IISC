﻿using Garage.Core.AppDbContext;
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

        public async Task<List<zRoleUser>> FindAccount(string username)
        {
            //AccountViewModel useracc = new AccountViewModel();
            //zRoleUser query = ;
            //if (query != null)
            //{
            //    //useracc.Username = username;
            //    foreach (var item in query)
            //    {
            //        useracc.Roles.Add(item.RoleName);
            //    }
            //}

            return await _context.zRoleUser.Where(x => x.UserId == username).ToListAsync();
        }

        public async Task<IEnumerable<zRoleUser>> Login(string username)
        {
            var query = await _context.zRoleUser.Where(x => x.UserId == username).ToListAsync();
            return query;
        }
    }
}