namespace FastFood.Services.Data
{
    using Web.ViewModels.Categories;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel inputModel);

        Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
    }
}
