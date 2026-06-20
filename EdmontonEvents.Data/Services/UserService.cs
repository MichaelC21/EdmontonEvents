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

        public async Task<UserAccount?> GetUserAccountByUserName(string username)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(u => (u.UserName != null ? u.UserName.Trim().ToLower() : "") == username.Trim().ToLower() && u.IsActive == true);
        }

    }
}
