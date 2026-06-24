using EdmontonEvents.Data;
using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Services;
using EdmontonEvents.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EdmontonEvents.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ApplicationDbContext context, IUserService userService)
            : base(context, userService)
        {
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await GetCurrentUserAccount();
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

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }

            ProfileDTO profile = new ProfileDTO(user);

            return View(profile);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileDTO profile)
        {
            var user = await GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }

            if(!String.IsNullOrEmpty(profile.PostalCode))
            {
                if (profile.PostalCode[3] != '-')
                {
                    ModelState.AddModelError("PostalCode", "Postal code must be in the form XXX-XXX");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.FirstName = profile.FirstName;
                    user.LastName = profile.LastName;
                    user.Email = profile.Email;
                    user.PhoneNumber = profile.PhoneNumber;
                    user.PostalCode = profile.PostalCode;

                    await Context.SaveChangesAsync();

                    profile.FormResult.Success = true;
                    profile.FormResult.Message = "Profile updated!";
                }
                catch (Exception e)
                {
                    //Implement a logger
                    ViewData["Message"] = new { msg = "Something went wrong please try again.", success = false };
                    profile.FormResult.Success = false;
                    profile.FormResult.Message = "Something went wrong please try again.";
                }
            }
            return View(profile);
        }
    }
}
