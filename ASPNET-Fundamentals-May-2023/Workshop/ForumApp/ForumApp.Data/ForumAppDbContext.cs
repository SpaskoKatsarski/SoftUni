namespace ForumApp.Data
{
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
            builder
                .Entity<Post>()
                .HasData
                (
                    new Post() { Id = 1, Title = "My first post", Content = "My first post will be about the cats. They are really funny and have their own website called http.cat!" },
                    new Post() { Id = 2, Title = "My second post", Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!" },
                    new Post() { Id = 3, Title = "My third post", Content = "I love dogs aswell. They are as funny as the cats and also have their own website representing the http status codes!" }
                );

            base.OnModelCreating(builder);
        }
    }
}
