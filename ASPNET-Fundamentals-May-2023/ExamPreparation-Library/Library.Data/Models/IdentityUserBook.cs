namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    
    using System.ComponentModel.DataAnnotations.Schema;

    public class IdentityUserBook
    {
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; } = null!;

        public IdentityUser Collector { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}
