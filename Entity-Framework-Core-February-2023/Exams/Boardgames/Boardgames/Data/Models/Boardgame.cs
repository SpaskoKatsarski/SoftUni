namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Models.Enums;

    public class Boardgame
    {
        public Boardgame()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public double Rating { get; set; }

        [MaxLength(2023)]
        public int YearPublished { get; set; }

        public CategoryType CategoryType { get; set; }

        public string Mechanics { get; set; } = null!;

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public Creator Creator { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
