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
    
    public class CommentController : Controller
    {
        private PersonalWebiteContext db = new PersonalWebiteContext();

        public ActionResult Create(int id)
        {
            var comment = new Comment();
            comment.Ramble = db.Rambles.Single(x => x.ID == id);
            comment.RambleId = comment.Ramble.ID; // ToDo: WTF?
            return View(comment);
        } 

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Ramble");  
            }

            return View(comment);
        }
        
        [Authorize]
        public ActionResult Edit(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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