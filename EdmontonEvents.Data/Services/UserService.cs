using EdmontonEvents.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdmontonEvents.Data.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetUserAccountByName(string name)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email.Trim().ToLower() == name.Trim().ToLower() && u.IsActive == true);
        }

    }
}
