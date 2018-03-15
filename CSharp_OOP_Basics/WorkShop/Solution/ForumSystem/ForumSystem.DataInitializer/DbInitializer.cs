namespace ForumSystem.DataInitializer
{
    using Data;

    public class DbInitializer
    {
        private ReplyGenerator replyGenerator;
        private PostGenerator postGenerator;
        private CategoryGenerator categoryGenerator;
        private UserGenerator userGenerator;
        private ForumSystemDbContext db;

        public DbInitializer(ForumSystemDbContext db)
        {
            this.replyGenerator = new ReplyGenerator();
            this.postGenerator = new PostGenerator();
            this.categoryGenerator = new CategoryGenerator();
            this.userGenerator = new UserGenerator();
            this.db = db;
        }

        public void ResetDatabase()
        {
            this.db.Database.EnsureDeleted();
            this.db.Database.EnsureCreated();
        }

        public void SeedData()
        {
            this.SeedUsers();
            this.SeedCategories();
            this.SeedPosts();
            this.SeedReplies();
        }

        private void SeedReplies()
        {
            var replies = this.replyGenerator
                .CreateReplies(this.db);

            this.db.Replies.AddRange(replies);

            this.db.SaveChanges();
        }

        private void SeedPosts()
        {
            var posts = this.postGenerator
                .CreatePosts(this.db);

            this.db.AddRange(posts);

            this.db.SaveChanges();
        }

        private void SeedCategories()
        {
            var categories = this.categoryGenerator
                .CreateCategories();

            this.db.Categories.AddRange(categories);

            this.db.SaveChanges();
        }

        private void SeedUsers()
        {
            var users = this.userGenerator
                .CreateUsers();

            this.db.Users.AddRange(users);

            this.db.SaveChanges();
        }
    }
}
