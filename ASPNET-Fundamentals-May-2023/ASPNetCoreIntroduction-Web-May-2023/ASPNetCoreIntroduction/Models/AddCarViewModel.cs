#nullable disable

namespace ASPNetCoreIntroduction.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddCarViewModel
    {
        [Required]
        [StringLength(20)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Range(1886, 2023)]
        public int Year { get; set; }

        [Required]
        [Range(0, Double.PositiveInfinity)]
        public decimal Price { get; set; }
    }
}
