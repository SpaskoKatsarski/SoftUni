namespace Homies.ViewModels.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public string Name { get; set; } = null!;

        public string StartingTime { get; set; } = null!;

        public string? EndingTime { get; set; }

        public string? CreatedOn { get; set; }

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;
    }
}
