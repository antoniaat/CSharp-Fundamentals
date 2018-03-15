using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Title) 
                || string.IsNullOrWhiteSpace(this.Content))
            {
                return false;
            }

            return true;
        }
    }
}