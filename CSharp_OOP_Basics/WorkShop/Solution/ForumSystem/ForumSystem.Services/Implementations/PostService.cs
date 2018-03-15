namespace ForumSystem.Services.Implementations
{
    using ForumSystem.Data;
    using ForumSystem.Models;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Models.Post;
    using ForumSystem.Services.Models.Reply;
    using System.Linq;

    public class PostService : IPostService
    {
        public bool Create(PostServiceModel model)
        {
            using (var db = new ForumSystemDbContext())
            {
                var newPost = new Post()
                {
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = db.Users.FirstOrDefault(u => u.Username == model.Author).Id,
                    CategoryId = db.Categories.First(c => c.Name == model.Category).Id
                };

                if (newPost.IsValid())
                {
                    db.Posts.Add(newPost);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public PostServiceModel GetById(int id)
        {
            using (var db = new ForumSystemDbContext())
            {
                var model = db.Posts
                    .Where(p => p.Id == id)
                    .Select(p => new PostServiceModel
                    {
                        Title = p.Title,
                        Content = p.Content,
                        Author = p.Author.Username,
                        Category = p.Category.Name,
                        Replies = p.Replies
                            .Select(r => new ReplyServiceModel
                            {
                                Content = r.Content,
                                Author = r.Author.Username
                            })
                            .ToArray()
                    })
                    .First();

                return model;
            }
        }
    }
}
