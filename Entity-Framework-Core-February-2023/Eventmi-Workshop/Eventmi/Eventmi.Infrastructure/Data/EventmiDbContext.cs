namespace Eventmi.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class EventmiDbContext : DbContext
    {
        public EventmiDbContext()
        {

        }

        public EventmiDbContext(DbContextOptions<EventmiDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; } = null!;
    }
}
