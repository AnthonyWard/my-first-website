using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class Tag
    {
        public Tag()
        {
            Created = DateTime.Now;
        }

        // Fields
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the Tag name")]
        [StringLength(20, ErrorMessage = "The Tag name must be 20 charachters or less")]
        public string Name { get; set; }
        public DateTime Created { get; set; }

        // Navigation

        // Relationships
        public virtual ICollection<Ramble> Rambles { get; set; }
    }
}