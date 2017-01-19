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
    public class ThreadController : Controller
    {
        private PersonalWebiteContext db = new PersonalWebiteContext();

        //
        // GET: /Thread/

        public ViewResult Index(int forumId)
        {
            var threads = db.Threads.Include(t => t.Forum).Include(t => t.User).Where(t => t.ForumId == forumId);
            return View(threads.ToList());
        }

        //
        // GET: /Thread/Details/5

        public ViewResult Details(int id)
        {
            Thread thread = db.Threads.Find(id);
            return View(thread);
        }

        //
        // GET: /Thread/Create

        public ActionResult Create(int forumId)
        {
            ViewBag.ForumId = new SelectList(db.Forums, "ID", "Name");
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name");
            return View();
        } 

        //
        // POST: /Thread/Create

        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Threads.Add(thread);
                db.SaveChanges();
                return RedirectToAction("Index", new { forumId = thread.ForumId });  
            }

            ViewBag.ForumId = new SelectList(db.Forums, "ID", "Name", thread.ForumId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", thread.UserId);
            return View(thread);
        }
        
        //
        // GET: /Thread/Edit/5
 
        public ActionResult Edit(int id)
        {
            Thread thread = db.Threads.Find(id);
            ViewBag.ForumId = new SelectList(db.Forums, "ID", "Name", thread.ForumId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", thread.UserId);
            return View(thread);
        }

        //
        // POST: /Thread/Edit/5

        [HttpPost]
        public ActionResult Edit(Thread thread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ForumId = new SelectList(db.Forums, "ID", "Name", thread.ForumId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", thread.UserId);
            return View(thread);
        }

        //
        // GET: /Thread/Delete/5
 
        public ActionResult Delete(int id)
        {
            Thread thread = db.Threads.Find(id);
            return View(thread);
        }

        //
        // POST: /Thread/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
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