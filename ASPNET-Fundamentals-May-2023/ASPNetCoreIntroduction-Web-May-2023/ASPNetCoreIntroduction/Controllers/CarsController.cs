namespace ASPNetCoreIntroduction.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ASPNetCoreIntroduction.Models;
    using ASPNetCoreIntroduction.Services;

    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (true)
            {
                ModelState.AddModelError("", "Unexpected error occured");
                return View(model);
            }

            // Logic for adding the car to the database...

            return RedirectToAction("Index", "Home");
        }
    }
}
