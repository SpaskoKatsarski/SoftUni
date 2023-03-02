namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Course
{
    public Course()
    {
        this.StudentCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
        this.Resources = new HashSet<Resource>();
    }

    [Key]
    public int CourseId { get; set; }

    [MaxLength(80)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }
}
