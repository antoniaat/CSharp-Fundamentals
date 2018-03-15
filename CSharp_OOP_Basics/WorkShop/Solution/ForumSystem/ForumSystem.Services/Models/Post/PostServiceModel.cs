namespace ForumSystem.Services.Models.Post
{
    using ForumSystem.Services.Models.Reply;
    using System.Collections.Generic;

    public class PostServiceModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public IList<ReplyServiceModel> Replies { get; set; } = new List<ReplyServiceModel>();
    }
}
