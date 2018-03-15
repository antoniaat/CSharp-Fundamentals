using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumSystem.Models
{
    public class User
    {
        private const int UsernameMinLength = 3;
        private const int PasswordMinLength = 3;

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Username) 
                || string.IsNullOrWhiteSpace(this.Password))
            {
                return false;
            }

            if (this.Username.Length < UsernameMinLength || this.Password.Length < PasswordMinLength)
            {
                return false;
            }

            return true;
        }
    }
}