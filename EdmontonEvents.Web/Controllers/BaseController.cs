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
        protected UserManager<UserAccount> UserManager { get; }
        public BaseController(ApplicationDbContext context, IUserService userService, UserManager<UserAccount> userManager)
        {
            Context = context;
            UserService = userService;
            UserManager = userManager;
        }

        protected UserAccount? GetCurrentUserAccount()
        {
            var id = UserManager.GetUserId(User);
            if (id == null)
            {
                return null;
            }

            return UserService.GetUserAccountByID(id);
        }
    }
}
