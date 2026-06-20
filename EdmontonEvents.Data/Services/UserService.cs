using EdmontonEvents.Data.Entities;
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

        public UserAccount? GetUserAccountByName(string name)
        {
            return _context.UserAccounts.FirstOrDefault(u => u.Email.Trim().ToLower() == name.Trim().ToLower() && u.IsActive == true);
        }

    }
}
