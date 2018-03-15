using System;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Content))
            {
                return false;
            }

            return true;
        }
    }
}