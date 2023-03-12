namespace FastFood.Services.Data
{
    using Web.ViewModels.Items;

    public interface IItemService
    {
        Task<IEnumerable<CreateItemViewModel>> GetAllAvailibleCategoriesAsync();

        Task CreateAsync(CreateItemInputModel inputModel);

        Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();
    }
}
