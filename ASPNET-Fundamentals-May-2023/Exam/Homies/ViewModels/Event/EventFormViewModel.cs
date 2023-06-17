namespace Homies.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using Homies.ViewModels.Type;
    using static Constants.ValidationConstants.Event;

    public class EventFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeOptionViewModel> Types { get; set; } = null!;
    }
}
