namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Data;
    using TaskBoardApp.Models.Board;
    using TaskBoardApp.Models.Task;

    public class BoardController : Controller
    {
        private readonly TaskBoardDbContext context;

        public BoardController(TaskBoardDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var boards = await context.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new TaskViewModel()
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
