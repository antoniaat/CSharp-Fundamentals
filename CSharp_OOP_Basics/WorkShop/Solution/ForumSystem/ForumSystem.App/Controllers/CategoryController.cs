namespace ForumSystem.App.Controllers
{

    using Enums;
    using ForumSystem.App.Controllers.Contracts;
    using ForumSystem.App.CustomExceptions;
    using ForumSystem.App.Views;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;
    using System.Linq;
    using UserInterface.Contracts;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;

        private ICategoryService categoryService;
        private string[] PostTitles;
        private int LastPage => this.PostTitles.Length / 11;
        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategoryId(1);
            this.categoryService = new CategoryService();
        }

        public int CategoryId { get; set; }

        public int CurrentPage { get; set; }

        private void ChangePage(bool forward)
        {
            this.CurrentPage += forward ? 1 : -1;
            this.GetPosts();
        }

        private void GetPosts()
        {
            var allPostsByCategoryId = this.categoryService.GetPostsById(this.CategoryId);

            this.PostTitles = allPostsByCategoryId
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }

        public void SetCategoryId(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.OpenCategory;
                case Command.NextPage:
                    this.ChangePage(true);
                    return MenuState.OpenCategory;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.GetPosts();

            var categoryName = this.categoryService.GetById(this.CategoryId).Name;

            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12,
        }
    }
}
