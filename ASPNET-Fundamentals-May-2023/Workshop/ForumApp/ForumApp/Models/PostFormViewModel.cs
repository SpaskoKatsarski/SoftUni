namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ForumApp.Common.ValidationConstants.Post;

    public class PostFormViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, 
            MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength,
            MinimumLength = ContentMinLength)]
        public string PostContent { get; set; } = null!;
    }
}
