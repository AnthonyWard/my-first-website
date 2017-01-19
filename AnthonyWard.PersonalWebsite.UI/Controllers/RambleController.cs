using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthonyWard.PersonalWebsite.UI.Models;
using AnthonyWard.PersonalWebsite.UI.ViewModel;

namespace AnthonyWard.PersonalWebsite.UI.Controllers
{ 
    public class RambleController : Controller
    {
        private PersonalWebiteContext db = new PersonalWebiteContext();

        //
        // GET: /Ramble/

        public ViewResult Index()
        {
            var rambles = db.Rambles
                .Include("Comments")
                .Include("Tags")
                .OrderByDescending(r => r.Created)
                .Take(5).ToList();

            var comments = new List<Comment>();

            foreach (var ramble in rambles)
            {
                foreach (var comment in ramble.Comments)
                {
                    comments.Add(comment);
                }
            }

            var vm = new RambleIndex
            {
                Rambles = rambles,
                Comments = comments.OrderByDescending(c => c.Created).Take(5).ToList(),
            };

            return View(vm);
        }

        //
        // GET: /Ramble/Details/5

        public ViewResult Details(int id)
        {
            Ramble ramble = db.Rambles.Find(id);
            return View(ramble);
        }

        //
        // GET: /Ramble/Create
        [Authorize]
        public ActionResult Create()
        {
            var users = db.Users.Select(x => new { Value = x.ID, Text = x.Name }).ToList();
            List<SelectListItem> sl = new List<SelectListItem>();
            users.ForEach(x => sl.Add( new SelectListItem { Value = x.Value.ToString(), Text = x.Text }));

            var vm = new RambleCreate
            {
                Ramble = new Ramble(),
                Users = sl,
            };

            return View(vm);
        } 

        //
        // POST: /Ramble/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(RambleCreate vm)
        {
            var ramble = vm.Ramble;
            if (ModelState.IsValid) // USER IS REQUIRED ARGH!!!!!!!!!!!
            {
                db.Rambles.Add(ramble);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(vm); // NEED TO MAKE THIS WORK
        }
        
        //
        // GET: /Ramble/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Ramble ramble = db.Rambles.Find(id);
            return View(ramble);
        }

        //
        // POST: /Ramble/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Ramble ramble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ramble);
        }

        //
        // GET: /Ramble/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Ramble ramble = db.Rambles.Find(id);
            return View(ramble);
        }

        //
        // POST: /Ramble/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Ramble ramble = db.Rambles.Find(id);
            db.Rambles.Remove(ramble);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}