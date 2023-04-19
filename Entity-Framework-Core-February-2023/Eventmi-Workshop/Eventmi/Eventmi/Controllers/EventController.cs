namespace Eventmi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Eventmi.Core.Contracts;
    using Eventmi.Core.Models;

    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ILogger logger;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<EventModel> model = null;

            try
            {
                model = await this.eventService.GetAllAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Index", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.View("All", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            EventModel model = new EventModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EventModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.eventService.AddAsync(model);
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Add", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            EventModel model;

            try
            {
                model = await this.eventService.GetEventAsync(id);

                return this.View(model);
            }
            catch (ArgumentException ae)
            {
                this.ViewBag.ErrorMessage = ae.Message;
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Details", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.eventService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Delete", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EventModel model;

            try
            {
                model = await this.eventService.GetEventAsync(id);

                return this.View(model);
            }
            catch (ArgumentException ae)
            {
                this.ViewBag.ErrorMessage = ae.Message;
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Edit", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.eventService.UpdateAsync(model);

                return this.RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (ArgumentException ae)
            {
                this.ViewBag.ErrorMessage = ae.Message;
            }
            catch (Exception e)
            {
                this.logger.LogError("EventController/Edit", e);
                this.ViewBag.ErrorMessage = "Unexpected error occured!";
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
