namespace Library.Controllers
{
    using System.Security.Claims;

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

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await this.bookService.GetByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All", "Book");
            }

            var userId = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return StatusCode(500);
            }

            await this.bookService.AddBookToUserAsync(book.Id, userId);

            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return StatusCode(500);
            }

            var books = await this.bookService.GetBooksForUserAsync(userId);

            return View(books);
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                return StatusCode(500);
            }

            await this.bookService.RemoveFromUserAsync(id, userId);

            return RedirectToAction("Mine", "Book");
        }
    }
}
