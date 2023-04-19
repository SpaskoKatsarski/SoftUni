namespace Eventmi.Core.Contracts
{
    using Eventmi.Core.Models;

    public interface IEventService
    {
        Task AddAsync(EventModel model);

        Task DeleteAsync(int id);

        Task UpdateAsync(EventModel model);

        Task<ICollection<EventModel>> GetAllAsync();

        Task<EventModel> GetEventAsync(int id);
    }
}
