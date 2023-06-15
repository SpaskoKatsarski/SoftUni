namespace Library.Services.Contracts
{
    using Library.ViewModels.Book;
    using Library.Data.Models;

    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> AllAsync();

        Task AddAsync(BookFormViewModel model);

        Task AddBookToUserAsync(int bookId, string collectorId);

        Task<BookViewModel> GetByIdAsync(int id);

        Task<IEnumerable<BookViewModel>> GetBooksForUserAsync(string userId);

        Task RemoveFromUserAsync(int id, string userId);
    }
}
