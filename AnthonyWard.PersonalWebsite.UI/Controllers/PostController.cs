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
    public class PostController : Controller
    {
        private PersonalWebiteContext db = new PersonalWebiteContext();

        //
        // GET: /Post/

        public ViewResult Index(int threadId)
        {
            var posts = db.Posts.Include(p => p.Thread).Include(p => p.User).Where(p => p.ThreadId == threadId);
            return View(posts.ToList());
        }

        //
        // GET: /Post/Details/5

        public ViewResult Details(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create(int threadId)
        {
            ViewBag.ThreadId = new SelectList(db.Threads, "ID", "Name");
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name");
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", new { threadId = post.ThreadId });  
            }

            ViewBag.ThreadId = new SelectList(db.Threads, "ID", "Name", post.ThreadId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", post.UserId);
            return View(post);
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            Post post = db.Posts.Find(id);
            ViewBag.ThreadId = new SelectList(db.Threads, "ID", "Name", post.ThreadId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", post.UserId);
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThreadId = new SelectList(db.Threads, "ID", "Name", post.ThreadId);
            ViewBag.UserId = new SelectList(db.Users, "ID", "Name", post.UserId);
            return View(post);
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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