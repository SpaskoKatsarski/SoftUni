﻿namespace Library.ViewModels.Book
{
    using Library.ViewModels.Category;

    public class BookFormViewModel
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
