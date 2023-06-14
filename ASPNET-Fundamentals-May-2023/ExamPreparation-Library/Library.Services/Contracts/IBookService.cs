namespace Library.Services.Contracts
{
    using Library.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> AllAsync();

        Task AddAsync(BookFormViewModel model);
    }
}
