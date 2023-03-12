namespace FastFood.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Positions;
    using FastFood.Services.Data;

    public class PositionsController : Controller
    {
        private readonly IPositionService positionService;

        public PositionsController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.positionService.CreateAsync(model);

            return this.RedirectToAction("All", "Positions");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<PositionsAllViewModel> positions = await this.positionService.GetAllAsync();

            return this.View(positions.ToList());
        }
    }
}
