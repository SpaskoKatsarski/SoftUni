namespace ForumApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;

    using ForumApp.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ForumApp.Data.Seeding;

    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;

        public PostEntityConfiguration()
        {
            this.postSeeder = new PostSeeder();
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.postSeeder.GeneratePosts());
        }
    }
}
