using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class User
    {
        public User()
        {
            Created = DateTime.Now;
        }

        // Fields
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public bool Disable { get; set; }

        // Relationships
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
    }
}