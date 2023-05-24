namespace TextSplitterApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TextViewModel
    {
        [Required(ErrorMessage = "The text field is required.")]
        [StringLength(30, MinimumLength = 2)]
        public string Text { get; set; } = null!;

        public string SplitText { get; set; } = null!;
    }
}
