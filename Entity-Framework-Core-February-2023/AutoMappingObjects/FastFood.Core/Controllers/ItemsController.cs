namespace FastFood.Web.Controllers
{
    using System;
    using FastFood.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availibleCategories = await this.itemService
                .GetAllAvailibleCategoriesAsync();

            return this.View(availibleCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.itemService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModel> items = await this.itemService.GetAllAsync();

            return this.View(items.ToList());
        }
    }
}
