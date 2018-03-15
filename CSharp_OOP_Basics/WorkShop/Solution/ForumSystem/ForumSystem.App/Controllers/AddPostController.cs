namespace ForumSystem.App.Controllers
{
    using Enums;
    using Controllers.Contracts;
    using CustomExceptions;
    using UserInterface;
    using UserInterface.Contracts;
    using UserInterface.Input;
    using UserInterface.ViewModels;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;
    using ForumSystem.Services.Models.Post;
    using System.Linq;

    public class AddPostController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 18;
        private const int POST_MAX_LENGTH = 660;

        private ICategoryService categoryService;
        private IPostService postService;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public AddPostController()
        {
            this.ResetPost();
            this.categoryService = new CategoryService();
            this.postService = new PostService();
        }
        
        public PostViewModel Post { get; private set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public void ReadTitle()
        {
            this.Post.Title = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadCategory()
        {
            this.Post.Category = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ResetPost()
        {
            this.Error = false;
            this.Post = new PostViewModel();
            this.TextArea = new TextArea(centerLeft - 18, centerTop - 7, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.AddTitle:
                    this.ReadTitle();
                    return MenuState.AddPost;
                case Command.AddCategory:
                    this.ReadCategory();
                    return MenuState.AddPost;
                case Command.Write:
                    this.TextArea.Write();
                    this.Post.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddPost;
                case Command.Post:
                    return this.TryToCreatePost();
            }

            throw new InvalidCommandException();
        }

        private MenuState TryToCreatePost()
        {
            var isCategoryExisting = this.categoryService.GetByName(this.Post.Category) != null;
            if (!isCategoryExisting)
            {
                this.categoryService.Create(this.Post.Category);
            }

            var serviceModel = new PostServiceModel()
            {
                Title = this.Post.Title,
                Content = string.Join(string.Empty, this.Post.Content),
                Category = this.Post.Category,
                Author = this.Post.Author
            };

            var postAddedSuccessfull = this.postService.Create(serviceModel);

            if (!postAddedSuccessfull)
            {
                this.Error = true;
                return MenuState.Rerender;
            }

            return MenuState.PostAdded;
        }

        public IView GetView(string userName)
        {
            this.Post.Author = userName;
            return new AddPostView(this.Post, this.TextArea, this.Error);
        }

        private enum Command
        {
            AddTitle,
            AddCategory,
            Write,
            Post
        }
    }
}
