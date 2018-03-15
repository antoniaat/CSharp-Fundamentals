namespace ForumSystem.Services.Implementations
{
    using ForumSystem.Data;
    using ForumSystem.Models;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Models.Reply;
    using System.Collections.Generic;
    using System.Linq;

    public class ReplyService : IReplyService
    {
        public bool Create(ReplyServiceModel model)
        {
            using (var db = new ForumSystemDbContext())
            {
                var reply = new Reply()
                {
                    Content = model.Content,
                    AuthorId = db.Users.First(u => u.Username == model.Author).Id,
                    PostId = model.PostId
                };

                if (reply.IsValid())
                {
                    db.Replies.Add(reply);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public IEnumerable<ReplyServiceModel> GetReplyModelsByPostId(int postId)
        {
            using (var db = new ForumSystemDbContext())
            {
                var replies = db.Replies
                    .Where(r => r.PostId == postId)
                    .Select(r => new ReplyServiceModel
                    {
                        Author = r.Author.Username,
                        Content = r.Content
                    })
                    .ToArray();

                return replies;
            }
        }
    }
}
