namespace ForumSystem.App.UserInterface.ViewModels
{
    using ForumSystem.Services.Models.Post;
    using ForumSystem.Services.Models.Reply;
    using System.Collections.Generic;
    using System.Linq;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel()
        {
        }

        public PostViewModel(PostServiceModel model)
        {
            this.PostId = model.PostId;
            this.Title = model.Title;
            this.Author = model.Author;
            this.Category = model.Category;
            this.Content = GetLines(model.Content);
            this.Replies = this.ConvertReplyServiceModels(model.Replies);
        }
        
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; } = new List<string>();

        public IList<ReplyViewModel> Replies { get; set; } = new List<ReplyViewModel>();

        private IList<ReplyViewModel> ConvertReplyServiceModels(IList<ReplyServiceModel> replies)
        {
            var replyViewModels = new List<ReplyViewModel>();

            foreach (var rsm in replies)
            {
                replyViewModels.Add(new ReplyViewModel(rsm));
            }

            return replyViewModels;
        }

        private IList<string> GetLines(string content)
        {
            var contentSymbols = content.ToCharArray();

            var lines = new List<string>();

            for (int symbol = 0; symbol < content.Length; symbol += LINE_LENGHT)
            {
                var currentRow = contentSymbols.Skip(symbol).Take(LINE_LENGHT).ToArray();

                string rowAsString = string.Join(string.Empty, currentRow);

                lines.Add(rowAsString);
            }

            return lines;
        }
    }
}
