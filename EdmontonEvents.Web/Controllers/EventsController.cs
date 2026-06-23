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

            EventDTO eventDTO = new EventDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return View(eventDTO);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(EventDTO eventDTO)
        {
            //The success logic will be replaced with a redirect to the event details page once that is implemented.
            var user = await GetCurrentUserAccount();
            if (user == null)
            {
                return Challenge();
            }
            if (ModelState.IsValid)
            {
                try
                {
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

                    eventDTO.FormResult.Success = true;
                    eventDTO.FormResult.Message = "Event created successfully.";

                } catch (Exception e)
                {
                    //Need to log exception
                    eventDTO.FormResult.Success = false;
                    eventDTO.FormResult.Message = "An error occurred while creating the event.";
                }

            }
            return View(eventDTO);
        }
    }
}

