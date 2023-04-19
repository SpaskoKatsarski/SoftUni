namespace Eventmi.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EventModel
    {
        public int Id { get; set; }

        [Display(Name = "Name of event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The field '{0}' should be between {2} and {1} symbols!")]
        public string Name { get; set; } = null!;

        [Display(Name = "Starting time of event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        public DateTime Start { get; set; }

        [Display(Name = "End time of event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        public DateTime End { get; set; }

        [Display(Name = "Place of event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The field '{0}' should be between {2} and {1} symbols!")]
        public string Place { get; set; } = null!;
    }
}
