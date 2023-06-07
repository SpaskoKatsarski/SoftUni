namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data.Models;

    public class TaskBoardDbContext : IdentityDbContext
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        private IdentityUser TestUser { get; set; }

        private Board OpenBoard { get; set; }

        private Board InProgressBoard { get; set; }

        private Board DoneBoard { get; set; }

        public DbSet<Board> Boards { get; set; } = null!;

        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed users
            builder
                .Entity<IdentityUser>()
                .HasData(this.TestUser);

            // Seed boards
            builder
                .Entity<Board>()
                .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            // TODO: Add 2 more tasks
            builder
                .Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for the home page",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                });

            base.OnModelCreating(builder);
        }
    }
}