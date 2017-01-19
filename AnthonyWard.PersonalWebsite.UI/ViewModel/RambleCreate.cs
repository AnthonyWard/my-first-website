using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnthonyWard.PersonalWebsite.UI.Models;
using System.Web.Mvc;

namespace AnthonyWard.PersonalWebsite.UI.ViewModel
{
    public class RambleCreate
    {
        public Ramble Ramble { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}