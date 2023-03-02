namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {

    }

    public StudentSystemContext(DbContextOptions options)
        : base(options)
    {
        
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<StudentCourse> StudentsCourses { get; set; }

    public DbSet<Homework> Homeworks { get; set; }

    public DbSet<Resource> Resources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity
            .Property(s => s.PhoneNumber)
            .HasMaxLength(10)
            .IsFixedLength();
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity
            .Property(r => r.Url)
            .IsUnicode(false);
        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity
            .Property(h => h.Content)
            .IsUnicode(false);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
        });
    }
}