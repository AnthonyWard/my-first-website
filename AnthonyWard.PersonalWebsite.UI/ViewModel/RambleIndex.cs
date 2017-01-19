using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnthonyWard.PersonalWebsite.UI.Models;

namespace AnthonyWard.PersonalWebsite.UI.ViewModel
{
    public class RambleIndex
    {
        public IList<Ramble> Rambles { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}