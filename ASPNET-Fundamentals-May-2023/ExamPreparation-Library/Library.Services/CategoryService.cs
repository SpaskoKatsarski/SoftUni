namespace Library.Services
{
    using Library.Data;
    using Library.Services.Contracts;
    using Library.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext context;

        public CategoryService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllAsync()
        {
            var categories = await this.context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return categories;
        }
    }
}
