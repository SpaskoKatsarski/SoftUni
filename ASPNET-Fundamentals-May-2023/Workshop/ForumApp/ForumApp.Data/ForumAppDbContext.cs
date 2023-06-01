namespace ForumApp.Data
{
    using ForumApp.Data.Configuration;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostEntityConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
