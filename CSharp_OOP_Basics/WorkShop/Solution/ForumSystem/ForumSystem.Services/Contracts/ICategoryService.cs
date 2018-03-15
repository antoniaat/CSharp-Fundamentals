using ForumSystem.Models;
using System.Collections.Generic;

namespace ForumSystem.Services.Contracts
{
    public interface ICategoryService
    {
        Category GetById(int categoryId);

        Category GetByName(string categoryName);

        bool Create(string name);

        IEnumerable<Post> GetPostsById(int categoryId);

        IEnumerable<string> GetAllCategoryNames();
    }
}
