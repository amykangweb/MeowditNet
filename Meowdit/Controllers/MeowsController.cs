using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Meowdit.DAL;
using Meowdit.Models;

namespace Meowdit.Controllers
{
    public class MeowsController : Controller
    {
        private MeowContext db = new MeowContext();

        // GET: Meows
        public ActionResult Index()
        {
            return View(db.Meows.ToList());
        }

        // GET: Meows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meow meow = db.Meows.Find(id);
            if (meow == null)
            {
                return HttpNotFound();
            }
            return View(meow);
        }

        // GET: Meows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Word")] Meow meow)
        {
            if (ModelState.IsValid)
            {
                db.Meows.Add(meow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meow);
        }

        // GET: Meows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meow meow = db.Meows.Find(id);
            if (meow == null)
            {
                return HttpNotFound();
            }
            return View(meow);
        }

        // POST: Meows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Word")] Meow meow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meow);
        }

        // GET: Meows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meow meow = db.Meows.Find(id);
            if (meow == null)
            {
                return HttpNotFound();
            }
            return View(meow);
        }

        // POST: Meows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meow meow = db.Meows.Find(id);
            db.Meows.Remove(meow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
