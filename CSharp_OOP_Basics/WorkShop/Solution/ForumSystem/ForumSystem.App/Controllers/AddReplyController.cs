namespace ForumSystem.App.Controllers
{
    using Controllers.Contracts;
    using Enums;
    using ForumSystem.App.CustomExceptions;
    using ForumSystem.App.UserInterface.Input;
    using ForumSystem.App.UserInterface.ViewModels;
    using ForumSystem.App.Views;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;
    using ForumSystem.Services.Models.Reply;
    using System.Linq;
    using UserInterface.Contracts;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private const int TOP_OFFSET = 7;

        private IPostService postService;
        private IReplyService replyService;
        private PostViewModel post;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public AddReplyController()
        {
            this.replyService = new ReplyService();
            this.postService = new PostService();
        }

        public int PostId { get; private set; }
        private ReplyViewModel Reply { get; set; }
        public TextArea TextArea { get; private set; }
        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;
                case Command.Submit:
                    return this.TryToCreateReply();
                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        private MenuState TryToCreateReply()
        {
            var isPostExisting = this.postService.GetById(this.PostId) != null;
            if (!isPostExisting)
            {
                throw new UnexistingPostException();
            }

            var serviceModel = new ReplyServiceModel()
            {
                Content = string.Join(string.Empty, this.Reply.Content),
                Author = this.Reply.Author,
                PostId = this.PostId
            };


            var replyAddedSuccessfull = this.replyService.Create(serviceModel);

            if (!replyAddedSuccessfull)
            {
                this.Error = true;
                return MenuState.Rerender;
            }

            return MenuState.ReplyAdded;
        }

        public void SetPostDetails(int postId, string author)
        {
            var serviceModel = this.postService.GetById(postId);

            this.post = new PostViewModel(serviceModel);

            this.PostId = postId;

            this.ResetReply();

            this.Reply.Author = author;
        }

        public void ResetReply()
        {
            var areaOffset = centerTop - (TOP_OFFSET - this.post.Content.Count) + 1;

            this.TextArea = new TextArea(centerLeft - 18, areaOffset, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);

            this.Reply = new ReplyViewModel();

            this.Error = false;
        }

        public IView GetView(string userName)
        {
            return new AddReplyView(this.post, this.Reply, this.TextArea, this.Error);
        }

        private enum Command
        {
            Write,
            Submit,
            Back,
        }
    }
}
