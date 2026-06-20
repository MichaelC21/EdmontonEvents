using EdmontonEvents.Data;
using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Services;
using EdmontonEvents.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EdmontonEvents.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ApplicationDbContext context, IUserService userService)
            : base(context, userService)
        {
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var user = GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }

            var vm = new AccountDashboardViewModel
            {
                FullName = $"{user.FirstName } {user.LastName}"
            };
            return View(vm);
        }
    }
}
