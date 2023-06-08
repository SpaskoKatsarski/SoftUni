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

            this.SeedUsers();
            builder
                .Entity<IdentityUser>()
                .HasData(this.TestUser);

            this.SeedBoards();
            builder
                .Entity<Board>()
                .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            
            builder
                .Entity<Task>()
                .HasData(new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for the home page",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.OpenBoard.Id
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.OpenBoard.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Desktop client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.InProgressBoard.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement 'Create Task' page for adding tasks through the browser",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.DoneBoard.Id
                });

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.TestUser = new IdentityUser()
            {
                UserName = "test@gmail.com",
                NormalizedUserName = "TEST@GMAIL.COM"
            };

            this.TestUser.PasswordHash = hasher.HashPassword(this.TestUser, "secret");
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Closed"
            };
        }
    }
}