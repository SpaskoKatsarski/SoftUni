namespace TaskBoardApp.Models.Task
{
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Data.DataConstants.Task;

    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength,
            ErrorMessage = "Title should be between {2} and {1} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength,
            ErrorMessage = "Description should be between {2} and {1} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
