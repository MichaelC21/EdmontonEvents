using EdmontonEvents.Data;
using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EdmontonEvents.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IUserService UserService;
        public BaseController(ApplicationDbContext context, IUserService userService)
        {
            Context = context;
            UserService = userService;
        }

        protected async Task<UserAccount?> GetCurrentUserAccount()
        {
            return await UserService.GetUserAccountByUserName(User.Identity.Name);
        }
    }
}
