namespace ForumApp.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string PostContent { get; set; } = null!;
    }
}
