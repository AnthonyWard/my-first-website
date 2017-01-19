using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthonyWard.PersonalWebsite.UI.Models;

namespace AnthonyWard.PersonalWebsite.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ViewResult Rambles()
        {
            var db = new PersonalWebiteContext();

            return View(
                db.Rambles
                .OrderByDescending(r => r.Created)
                .Take(5)
            );
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
