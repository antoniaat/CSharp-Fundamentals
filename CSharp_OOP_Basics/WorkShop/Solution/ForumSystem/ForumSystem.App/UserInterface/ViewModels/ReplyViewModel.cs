namespace ForumSystem.App.UserInterface.ViewModels
{
    using ForumSystem.Services.Models.Reply;
    using System.Collections.Generic;
    using System.Linq;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel()
        {
        }

        public ReplyViewModel(ReplyServiceModel model)
        {
            this.Content = this.GetLines(model.Content);
            this.Author = model.Author;
        }

        public int PostId { get; set; }

        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            var contentSymbols = content.ToCharArray();

            var lines = new List<string>();

            for (int symbol = 0; symbol < content.Length; symbol += LINE_LENGHT)
            {
                var currentRow = contentSymbols.Skip(symbol).Take(LINE_LENGHT).ToArray();

                string rowString = string.Join(string.Empty, currentRow);

                lines.Add(rowString);
            }

            return lines;
        }
    }
}