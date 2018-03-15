namespace ForumSystem.DataInitializer
{
    using Models;
    using System.Collections.Generic;

    internal class CategoryGenerator
    {
        internal IEnumerable<Category> CreateCategories()
        {
            var categoryNames = new string[]
            {
                "Rent-a-Coder",
                "News",
                "OffTopic",
                "Questions",
                "Social Groups",
                "Tutorials",
                "Newbies"
            };

            var categories = new List<Category>();

            foreach (var categoryName in categoryNames)
            {
                categories.Add(new Category()
                {
                    Name = categoryName
                });
            }

            return categories;
        }
    }
}