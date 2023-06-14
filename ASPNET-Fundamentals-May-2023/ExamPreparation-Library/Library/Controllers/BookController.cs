namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Library.Services.Contracts;
    using Library.ViewModels.Book;

    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            var books = await bookService.AllAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookFormViewModel model = new BookFormViewModel()
            {
                Categories = await this.categoryService.AllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.bookService.AddAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
