namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Data.DataConstants.Board;

    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }
    }
}
