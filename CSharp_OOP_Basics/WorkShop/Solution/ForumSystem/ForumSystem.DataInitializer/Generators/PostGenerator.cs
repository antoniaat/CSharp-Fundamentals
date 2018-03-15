namespace ForumSystem.DataInitializer
{
    using ForumSystem.Models;
    using ForumSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PostGenerator
    {
        private Random random = new Random();

        internal IEnumerable<Post> CreatePosts(ForumSystemDbContext db)
        {
            var sampleContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var allUsersIds = db
                .Users
                .Select(u => u.Id)
                .ToArray();

            var allCategoriesIds = db
                .Categories
                .Select(c => c.Id)
                .ToArray();

            var posts = new List<Post>();

            for (int i = 1; i < 100; i++)
            {
                var postTitle = $"Post #{i}";
                var authorId = allUsersIds[this.random.Next(0, allUsersIds.Length)];
                var categoryId = allCategoriesIds[this.random.Next(0, allCategoriesIds.Length)];

                posts.Add(new Post()
                {
                    Title = postTitle,
                    Content = sampleContent,
                    AuthorId = authorId,
                    CategoryId = categoryId
                });
            }

            return posts;
        }
    }
}