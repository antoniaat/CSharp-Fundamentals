namespace ForumSystem.App.Controllers
{
    using Enums;
    using ForumSystem.App.Controllers.Contracts;
    using ForumSystem.App.CustomExceptions;
    using ForumSystem.App.UserInterface;
    using ForumSystem.App.UserInterface.Contracts;
    using ForumSystem.App.UserInterface.ViewModels;
    using ForumSystem.App.Views;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;

    public class PostDetailsController : IController, IUserRestrictedController
    {
        private IPostService postService;

        public PostDetailsController()
        {
            this.postService = new PostService();
        }

        public int PostId { get; private set; }

        public bool LoggedInUser { get; set; }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReply:
                    return MenuState.AddReplyToPost;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            var serviceModel = this.postService.GetById(this.PostId);

            var viewModel = new PostViewModel(serviceModel);

            return new PostDetailsView(viewModel, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        private enum Command
        {
            Back,
            AddReply
        }
    }
}
