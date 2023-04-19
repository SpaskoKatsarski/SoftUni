namespace Eventmi.Core.Services
{
    using Microsoft.EntityFrameworkCore;

    using Eventmi.Core.Contracts;
    using Eventmi.Core.Models;
    using Eventmi.Infrastructure.Data.Common;
    using Eventmi.Infrastructure.Data.Models;

    public class EventService : IEventService
    {
        private readonly IRepository repo;

        public EventService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddAsync(EventModel model)
        {
            Event entity = new Event()
            {
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                Place = model.Place,
            };

            await this.repo.AddAsync(entity);
            await this.repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this.repo.DeleteAsync<Event>(id);
            await this.repo.SaveChangesAsync();
        }

        public async Task<ICollection<EventModel>> GetAllAsync()
        {
            return await this.repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        public async Task<EventModel> GetEventAsync(int id)
        {
            Event entity = await this.repo.GetByIdAsync<Event>(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            return new EventModel()
            {
                Name = entity.Name,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place
            };
        }

        public async Task UpdateAsync(EventModel model)
        {
            Event entity = await this.repo.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid ID", nameof(model.Id));
            }

            entity.Name = model.Name;
            entity.Start = model.Start;
            entity.End = model.End;
            entity.Place = model.Place;

            await this.repo.SaveChangesAsync();
        }
    }
}
