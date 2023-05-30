namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using ForumApp.Data;
    using ForumApp.Data.Models;

    public class PostController : Controller
    {
        // It's better to work with services, not directly with the context
        private readonly ForumAppDbContext context;

        public PostController(ForumAppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            List<PostViewModel> posts = await this.context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    PostContent = p.Content,
                })
                .ToListAsync();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.PostContent
            };

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await this.context.Posts.FindAsync(id);

            if (post == null)
            {
                return StatusCode(500);
            }

            var postViewModel = new PostFormViewModel()
            {
                Title = post.Title,
                PostContent = post.Content
            };

            return View(postViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormViewModel model)
        {
            var post = await this.context.Posts.FindAsync(id);

            if (post == null)
            {
                // Internal server error
                return StatusCode(500);
            }

            post.Title = model.Title;
            post.Content = model.PostContent;

            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await this.context.Posts.FindAsync(id);

            if (post == null)
            {
                return StatusCode(500);
            }

            this.context.Remove(post);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
