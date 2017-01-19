using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class Comment
    {
        public Comment()
        {
            Created = DateTime.Now;
        }
        // Fields
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public int? RambleId { get; set; }

        // Navigation
        public virtual Ramble Ramble { get; set; }

        // Relationships
    }
}