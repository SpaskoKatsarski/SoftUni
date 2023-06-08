namespace TaskBoardApp.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data;
    using TaskBoardApp.Data.Models;
    using TaskBoardApp.Models.Task;

    public class TaskController : Controller
    {
        private readonly TaskBoardDbContext context;

        public TaskController(TaskBoardDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                Boards = this.GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!this.GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = this.GetBoards();
                return View(model);
            }

            var task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = this.GetUserId()
            };

            await this.context.Tasks.AddAsync(task);
            await this.context.SaveChangesAsync();

            var boards = this.context.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await this.context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return BadRequest();
            }

            var taskModel = new TaskDetailsViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedOn = task.CreatedOn.ToString("dd/MM/yy HH:mm"),
                Owner = task.Owner.UserName
            };

            return View(taskModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await this.context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = this.GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            var task = await this.context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = this.GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!this.GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Boards = this.GetBoards();

                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await this.context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            return this.context.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                });
        }
    }
}
