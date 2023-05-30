namespace ForumApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
