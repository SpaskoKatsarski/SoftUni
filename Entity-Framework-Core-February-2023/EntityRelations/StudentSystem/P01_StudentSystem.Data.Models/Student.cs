namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Student
{
    public Student()
    {
        this.StudentCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    //Judge may want this as string
    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}