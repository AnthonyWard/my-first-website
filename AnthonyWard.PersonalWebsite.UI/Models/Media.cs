using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class Media
    {
        // Fields
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the name for the Media")]
        [StringLength(50, ErrorMessage = "The name of the Media must be 50 charachters or less")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the description for the Media")]
        [StringLength(100, ErrorMessage = "The description of the Media must be 100 charachters or less")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public bool Hide { get; set; }

        // Navigation
        public virtual User User { get; set; }
        public virtual MediaType MediaType { get; set; }

        // Relationships
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }

    public class MediaType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}