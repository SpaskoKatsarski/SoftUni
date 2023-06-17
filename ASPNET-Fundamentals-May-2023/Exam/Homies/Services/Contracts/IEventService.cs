namespace Homies.Services.Contracts
{
    using Homies.ViewModels.Event;

    public interface IEventService
    {
        Task<bool> IsOwnerAsync(int eventId, string userId);

        Task AddAsync(EventFormViewModel model, string organizerId);

        Task<IEnumerable<EventViewModel>> AllAsync();

        Task EditAsync(EventFormViewModel model);

        Task LeaveAsync(int eventId, string userId);

        Task<EventFormViewModel> GetEventInfoAsync(int eventId);

        Task<EventViewModel> GetForDetailsAsync(int eventId);

        Task<IEnumerable<EventViewModel>> JoinedEventsAsync(string userId);

        Task JoinUserToEventAsync(string userId, int eventId);

        Task<bool> IsParticipantAsync(string userdId, int eventId);
    }
}
