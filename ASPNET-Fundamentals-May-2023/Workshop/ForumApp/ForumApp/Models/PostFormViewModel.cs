namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants;

    public class PostFormViewModel
    {
        [Required]
        [StringLength(ValidationConstants.TitleMaxLength, 
            MinimumLength = ValidationConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.ContentMaxLength,
            MinimumLength = ValidationConstants.ContentMinLength)]
        public string PostContent { get; set; } = null!;
    }
}
