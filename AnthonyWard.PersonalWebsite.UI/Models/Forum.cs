using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class Forum
    {
        public Forum()
        {
            Created = DateTime.Now;
        }

        // Fields
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the name for the Forum")]
        [StringLength(50, ErrorMessage = "The name of the Forum must be 50 charachters or less")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the description for the Forum")]
        [StringLength(100, ErrorMessage = "The description of the Forum must be 100 charachters or less")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "The created date must be in a dd/mm/yyyy format")]
        public DateTime Created { get; set; }
        [Required]
        public bool Hide { get; set; }

        // Relationships
        public virtual ICollection<Thread> Threads { get; set; }
    }

    public class Thread
    {
        public Thread()
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
        public bool Hide { get; set; }

        // Navigation
        public int ForumId { get; set; }
        public virtual Forum Forum { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        // Relationships
        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public Post()
        {
            Created = DateTime.Now;
        }

        // Fields
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public bool Hide { get; set; }

        // Navigation
        public int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        // Relationships
    }
}