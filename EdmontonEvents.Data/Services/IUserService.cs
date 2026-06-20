using EdmontonEvents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdmontonEvents.Data.Services
{
    public interface IUserService
    {
        Task<UserAccount?> GetUserAccountByUserName(string name);
    }
}
