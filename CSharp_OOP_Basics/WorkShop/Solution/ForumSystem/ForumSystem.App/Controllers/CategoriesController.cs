namespace ForumSystem.App.Controllers
{
    using Controllers.Contracts;
    using Enums;
    using ForumSystem.App.CustomExceptions;
    using ForumSystem.App.Views;
    using ForumSystem.Services.Contracts;
    using ForumSystem.Services.Implementations;
    using System;
    using System.Linq;
    using UserInterface.Contracts;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;

        private ICategoryService categoryService;
        private string[] CurrentPageCategories;
        private string[] AllCategoryNames;
        private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);
        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public CategoriesController()
        {
            this.categoryService = new CategoryService();
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        private void LoadCategories()
        {
            this.AllCategoryNames = this.categoryService.GetAllCategoryNames().ToArray();

            this.CurrentPageCategories = this.AllCategoryNames
                    .Skip(this.CurrentPage * PAGE_OFFSET)
                    .Take(PAGE_OFFSET)
                    .ToArray();
        }
        
        private void ChangePage(bool forward)
        {
            this.CurrentPage += forward ? 1 : -1;
            this.LoadCategories();
        }

        public int CurrentPage { get; set; }

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
                case Command.ViewCategory:
                    return MenuState.OpenCategory;
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage(true);
                    return MenuState.Rerender;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
        }

        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12,
        }
    }
}
