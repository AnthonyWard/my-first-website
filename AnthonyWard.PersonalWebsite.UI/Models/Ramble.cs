using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class Ramble
    {
        public Ramble()
        {
            Created = DateTime.Now;
        }

        // Fields
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the name for this Ramble")]
        [StringLength(50, ErrorMessage = "The name of this Ramble must be 50 charachters or less")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter the description for this Ramble")]
        [StringLength(1000, ErrorMessage = "The description of this Ramble must be 1000 charachters or less")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Body { get; set; }

        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public bool Hide { get; set; }

        // Navigation
        public int UserId { get; set; }
        public virtual User User { get; set; } // USER IS REQUIRED ARGH!!!!!!!!!!!

        // Relationships
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}