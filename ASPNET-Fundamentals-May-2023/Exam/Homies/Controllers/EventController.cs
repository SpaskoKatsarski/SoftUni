namespace Homies.Controllers
{
    using Homies.ViewModels.Event;
    using Homies.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;

        public EventController(IEventService eventService, ITypeService typeService)
        {
            this.eventService = eventService;
            this.typeService = typeService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventFormViewModel model = new EventFormViewModel()
            {
                Types = await this.typeService.AllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return View();
            }

            await this.eventService.AddAsync(model, userId);

            return RedirectToAction("All", "Event");
        }

        //TODO: Fix the date format
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return View();
            }

            if (!await this.eventService.IsOwnerAsync(id, userId))
            {
                return RedirectToAction("All", "Event");
            }

            EventFormViewModel model = await this.eventService.GetEventInfoAsync(id);
            
            model.Id = id;
            model.Types = await this.typeService.AllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model)
        {
            await this.eventService.EditAsync(model);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> All()
        {
            var allEvents = await this.eventService.AllAsync();

            return View(allEvents);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.eventService.GetForDetailsAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return RedirectToAction("All", "Event");
            }

            if (await this.eventService.IsParticipantAsync(userId, id))
            {
                return RedirectToAction("All", "Event");
            }

            await this.eventService.JoinUserToEventAsync(userId, id);

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            string userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return View();
            }

            var events = await this.eventService.JoinedEventsAsync(userId);

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return View();
            }

            await this.eventService.LeaveAsync(id, userId);

            return RedirectToAction("All", "Event");
        }
    }
}
