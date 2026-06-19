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

        public UserAccount GetUserAccountByID(string id)
        {
            return _context.UserAccounts.First(u => u.Id == id);
        }

    }
}
