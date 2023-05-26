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
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }

            string[] words = model.Text.Split(' ',
                StringSplitOptions.RemoveEmptyEntries);

            string splitText = String.Join(Environment.NewLine, words);
            //model.Text = string.Empty;
            model.SplitText = splitText;

            return RedirectToAction("Index", model);
        }
    }
}