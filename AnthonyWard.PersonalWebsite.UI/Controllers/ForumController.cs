using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnthonyWard.PersonalWebsite.UI.Models;

namespace AnthonyWard.PersonalWebsite.UI.Controllers
{ 
    public class ForumController : Controller
    {
        private PersonalWebiteContext db = new PersonalWebiteContext();

        //
        // GET: /Forum/

        public ViewResult Index()
        {
            return View(db.Forums.ToList());
        }

        //
        // GET: /Forum/Details/5

        public ViewResult Details(int id)
        {
            Forum forum = db.Forums.Find(id);
            return View(forum);
        }

        //
        // GET: /Forum/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Forum/Create

        [HttpPost]
        public ActionResult Create(Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Forums.Add(forum);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(forum);
        }
        
        //
        // GET: /Forum/Edit/5
 
        public ActionResult Edit(int id)
        {
            Forum forum = db.Forums.Find(id);
            return View(forum);
        }

        //
        // POST: /Forum/Edit/5

        [HttpPost]
        public ActionResult Edit(Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forum);
        }

        //
        // GET: /Forum/Delete/5
 
        public ActionResult Delete(int id)
        {
            Forum forum = db.Forums.Find(id);
            return View(forum);
        }

        //
        // POST: /Forum/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Forum forum = db.Forums.Find(id);
            db.Forums.Remove(forum);
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