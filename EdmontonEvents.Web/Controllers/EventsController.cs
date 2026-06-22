using EdmontonEvents.Data;
using EdmontonEvents.Data.Entities;
using EdmontonEvents.Data.Models;
using EdmontonEvents.Data.Services;
using EdmontonEvents.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdmontonEvents.Web.Controllers
{
    public class EventsController : BaseController
    {
        public EventsController(ApplicationDbContext context, IUserService userService)
            : base(context, userService)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }

            ViewData["First Name"] = user.FirstName;
            ViewData["Last Name"] = user.LastName;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(EventDTO eventDTO)
        {
            var user = await GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }

            Event newEvent = new Event
            {
                UserID = user.Id,
                OrganizerFirstName = eventDTO.FirstName,
                OrganizerLastName = eventDTO.LastName,
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                StartUtc = eventDTO.EventStartDate.ToUniversalTime(),
                EndUtc = eventDTO.EventEndDate?.ToUniversalTime(),
                Location = eventDTO.Location,
                Status = EventStatus.Published,
                ExternalUrl = eventDTO.ExternalUrl,
                ImageUrl = eventDTO.ImageUrl,
                EventCategory = eventDTO.EventCategory,
                Price = eventDTO.Price,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow,
            };

            Context.Events.Add(newEvent);
            user.Events.Add(newEvent);

            await Context.SaveChangesAsync();

            return View(eventDTO);
        }
    }
}
