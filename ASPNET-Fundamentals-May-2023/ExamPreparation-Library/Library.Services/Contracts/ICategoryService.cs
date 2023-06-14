namespace Library.Services.Contracts
{
    using Library.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllAsync();
    }
}
