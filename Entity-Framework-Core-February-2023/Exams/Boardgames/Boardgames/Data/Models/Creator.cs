namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(7)]
        public string FirstName { get; set; } = null!;

        [MaxLength(7)]
        public string LastName { get; set; } = null!;

        public ICollection<Boardgame> Boardgames { get; set; }
    }
}
