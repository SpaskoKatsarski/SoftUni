using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel model)
            => View(model);

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var splitText = model.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            model.SplitText = String.Join(Environment.NewLine, splitText);

            return RedirectToAction("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}