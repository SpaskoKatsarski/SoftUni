namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Seller
    {
        public Seller()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [MaxLength(30)]
        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Website { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
