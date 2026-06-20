using EdmontonEvents.Data;
using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EdmontonEvents.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext Context { get; }
        protected IUserService UserService { get; }
        public BaseController(ApplicationDbContext context, IUserService userService)
        {
            Context = context;
            UserService = userService;
        }

        protected UserAccount? GetCurrentUserAccount()
        {
            return UserService.GetUserAccountByName(User.Identity.Name);
        }
    }
}
