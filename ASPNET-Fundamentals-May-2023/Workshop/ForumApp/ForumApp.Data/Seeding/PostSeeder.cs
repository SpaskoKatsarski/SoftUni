namespace ForumApp.Data.Seeding
{
    using ForumApp.Data.Models;

    class PostSeeder
    {
        internal ICollection<Post> GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post currentPost = new Post() { Id = 1, Title = "My first post", Content = "My first post will be about the cats. They are really funny and have their own website called http.cat!" };

            posts.Add(currentPost);

            currentPost = new Post() { Id = 2, Title = "My second post", Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!" };

            posts.Add(currentPost);

            currentPost = new Post() { Id = 3, Title = "My third post", Content = "I love dogs aswell. They are as funny as the cats and also have their own website representing the http status codes!" };

            posts.Add(currentPost);

            return posts;
        } 
    }
}
