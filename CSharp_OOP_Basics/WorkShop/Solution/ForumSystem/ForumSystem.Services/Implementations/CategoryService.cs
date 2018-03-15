namespace ForumSystem.Services.Implementations
{
    using ForumSystem.Data;
    using ForumSystem.Models;
    using ForumSystem.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        public bool Create(string name)
        {
            using (var db = new ForumSystemDbContext())
            {
                var category = new Category()
                {
                    Name = name
                };

                if (category.IsValid())
                {
                    db.Categories.Add(category);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public IEnumerable<string> GetAllCategoryNames()
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Categories
                    .Select(c => c.Name)
                    .ToArray();
            }
        }

        public Category GetById(int categoryId)
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Categories.Find(categoryId);
            }
        }

        public Category GetByName(string categoryName)
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Categories.FirstOrDefault(c => c.Name == categoryName);
            }
        }

        public IEnumerable<Post> GetPostsById(int categoryId)
        {
            using (var db = new ForumSystemDbContext())
            {
                return db.Posts
                    .Where(p => p.CategoryId == categoryId)
                    .ToArray();
            }
        }
    }
}
