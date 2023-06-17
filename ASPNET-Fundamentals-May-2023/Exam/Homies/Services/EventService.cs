namespace Homies.Service
{
    using Homies.Data;
    using Homies.Data.Models;
    using Homies.ViewModels.Event;
    using Homies.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(EventFormViewModel model, string organizerId)
        {
            var currEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = organizerId,
                CreatedOn = DateTime.UtcNow,
                Start = DateTime.Parse(model.Start),
                End = DateTime.Parse(model.End),
                TypeId = model.TypeId
            };

            await this.context.Events.AddAsync(currEvent);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventViewModel>> AllAsync()
        {
            var allEvents = await this.context
                .Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    StartingTime = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return allEvents;
        }

        public async Task EditAsync(EventFormViewModel model)
        {
            var eventToEdit = await this.context.Events.FindAsync(model.Id);

            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = DateTime.Parse(model.Start);
            eventToEdit.End = DateTime.Parse(model.End);
            eventToEdit.TypeId = model.TypeId;

            await this.context.SaveChangesAsync();
        }

        public async Task<EventFormViewModel> GetEventInfoAsync(int eventId)
        {
            var selectedEvent = await this.context
                .Events
                .FirstAsync(e => e.Id == eventId);

            var model = new EventFormViewModel()
            {
                Name = selectedEvent.Name,
                Description = selectedEvent.Description,
                Start = selectedEvent.Start.ToString("yyyy-MM-dd H:mm"),
                End = selectedEvent.End.ToString("yyyy-MM-dd H:mm"),
                TypeId = selectedEvent.TypeId
            };

            return model;
        }

        public async Task<EventViewModel> GetForDetailsAsync(int eventId)
        {
            var currEvent = await this.context.Events
                .Include(e => e.Organiser)
                .Include(e => e.Type)
                .FirstAsync(e => e.Id == eventId);

            var model = new EventViewModel()
            {
                Id = currEvent.Id,
                Name = currEvent.Name,
                Description = currEvent.Description,
                StartingTime = currEvent.Start.ToString("yyyy-MM-dd H:mm"),
                EndingTime = currEvent.End.ToString("yyyy-MM-dd H:mm"),
                Organiser = currEvent.Organiser.UserName,
                CreatedOn = currEvent.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Type = currEvent.Type.Name
            };

            return model;
        }

        public async Task<bool> IsOwnerAsync(int eventId, string userId)
        {
            var currEvent = await this.context.Events
                .FindAsync(eventId);

            return currEvent.OrganiserId == userId;
        }

        public async Task<bool> IsParticipantAsync(string userdId, int eventId)
        {
            return await this.context.EventsParticipants
                .AnyAsync(ep => ep.HelperId == userdId
                && ep.EventId == eventId);
        }

        public async Task<IEnumerable<EventViewModel>> JoinedEventsAsync(string id)
        {
            var events = await this.context.EventsParticipants
                .Where(ep => ep.HelperId == id)
                .Select(ep => new EventViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    StartingTime = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName
                })
                .ToListAsync();

            return events;
        }

        public async Task JoinUserToEventAsync(string userId, int eventId)
        {
            this.context.EventsParticipants.Add(new EventParticipant()
            {
                HelperId = userId,
                EventId = eventId
            });

            await this.context.SaveChangesAsync();
        }

        public async Task LeaveAsync(int eventId, string userId)
        {
            var ep = await this.context.EventsParticipants
                .FirstAsync(ep => ep.HelperId == userId
                && ep.EventId == eventId);

            this.context.EventsParticipants.Remove(ep);
            await this.context.SaveChangesAsync();
        }
    }
}
