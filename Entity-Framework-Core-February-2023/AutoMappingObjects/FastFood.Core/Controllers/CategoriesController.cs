namespace FastFood.Web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Categories;
    using Services.Data;
    using Models;

    public class CategoriesController : Controller
    {
        private ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.categoryService.CreateAsync(model);
            
            return this.RedirectToAction("All");
        }

        public async Task <IActionResult> All()
        {
            IEnumerable<CategoryAllViewModel> categories = await this.categoryService.GetAllAsync();

            return this.View(categories.ToList());
        }
    }
}
