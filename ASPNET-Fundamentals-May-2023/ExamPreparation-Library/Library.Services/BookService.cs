namespace Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Library.Data;
    using Library.ViewModels.Book;
    using Library.Services.Contracts;
    using Library.Data.Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task AddAsync(BookFormViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await this.context.AddAsync(book);
            await this.context.SaveChangesAsync();
        }

        public async Task AddBookToUserAsync(int bookId, string collectorId)
        {
            bool isAdded = await this.context.UsersBooks
                .AnyAsync(ub => ub.BookId == bookId && ub.CollectorId == collectorId);

            if (!isAdded)
            {
                await this.context.AddAsync(new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = collectorId
                });
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> AllAsync()
        {
            var books = await this.context.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating
                }).ToListAsync();

            return books;
        }

        public async Task<IEnumerable<BookViewModel>> GetBooksForUserAsync(string userId)
        {
            var books = await this.context.UsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new BookViewModel()
                {
                    Id = ub.BookId,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name,
                    ImageUrl = ub.Book.ImageUrl
                }).ToListAsync();

            return books;
        }

        public async Task<BookViewModel> GetByIdAsync(int id)
        {
            var book = await this.context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var bookModel = new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = book.Category.Name,
                ImageUrl = book.ImageUrl,
                Rating = book.Rating,
                Description = book.Description
            };

            return bookModel;
        }

        public async Task RemoveFromUserAsync(int id, string userId)
        {
            var userBook = this.context.UsersBooks
                .FirstOrDefault(ub => ub.BookId == id && ub.CollectorId == userId);

            this.context.UsersBooks.Remove(userBook);
            await this.context.SaveChangesAsync();
        }
    }
}