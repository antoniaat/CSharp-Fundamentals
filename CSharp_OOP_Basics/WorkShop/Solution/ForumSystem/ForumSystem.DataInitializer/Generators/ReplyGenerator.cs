namespace ForumSystem.DataInitializer
{
    using ForumSystem.Models;
    using ForumSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ReplyGenerator
    {
        private Random random = new Random();

        internal IEnumerable<Reply> CreateReplies(ForumSystemDbContext db)
        {
            var sampleContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var allUsersIds = db
                .Users
                .Select(u => u.Id)
                .ToArray();

            var allPostsIds = db
                .Posts
                .Select(c => c.Id)
                .ToArray();

            var replies = new List<Reply>();

            for (int i = 1; i < 300; i++)
            {
                var authorId = allUsersIds[this.random.Next(0, allUsersIds.Length)];
                var postId = allPostsIds[this.random.Next(0, allPostsIds.Length)];

                replies.Add(new Reply()
                {
                    Content = sampleContent,
                    AuthorId = authorId,
                    PostId = postId
                });
            }

            return replies;
        }
    }
}