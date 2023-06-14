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

        public async Task<IEnumerable<AllBookViewModel>> AllAsync()
        {
            var books = await this.context.Books
                .Select(b => new AllBookViewModel()
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
    }
}