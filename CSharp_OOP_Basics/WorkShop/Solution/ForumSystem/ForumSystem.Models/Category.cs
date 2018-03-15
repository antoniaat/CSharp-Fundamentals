namespace ForumSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(this.Name);
        }
    }
}
