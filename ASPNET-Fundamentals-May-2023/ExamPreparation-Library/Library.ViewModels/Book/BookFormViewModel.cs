namespace Library.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using Library.ViewModels.Category;

    public class BookFormViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;
        
        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
