using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Magfinalproject.Models;
using Microsoft.AspNet.Identity;

namespace Magfinalproject.Controllers
{
    [Authorize]
    public class acadyearsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: acadyears
        public ActionResult Index()
        {
            var acadyears = db.acadyears.Include(a => a.user);
            return View(acadyears.ToList());
        }

        // GET: acadyears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acadyear acadyear = db.acadyears.Find(id);
            if (acadyear == null)
            {
                return HttpNotFound();
            }
            return View(acadyear);
        }
        
        // GET: acadyears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acadyears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,date,userid")] acadyear acadyear)
        {
            if (ModelState.IsValid)
            {
                acadyear.userid= User.Identity.GetUserId();
                acadyear.date = DateTime.Now;
                db.acadyears.Add(acadyear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acadyear);
        }

        // GET: acadyears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acadyear acadyear = db.acadyears.Find(id);
            if (acadyear == null)
            {
                return HttpNotFound();
            }
            return View(acadyear);
        }

        // POST: acadyears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,date,userid")] acadyear acadyear)
        {
            if (ModelState.IsValid)
            {
                acadyear.userid = User.Identity.GetUserId();
                acadyear.date = DateTime.Now;
                db.Entry(acadyear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acadyear);
        }

        // GET: acadyears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acadyear acadyear = db.acadyears.Find(id);
            if (acadyear == null)
            {
                return HttpNotFound();
            }
            return View(acadyear);
        }

        // POST: acadyears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acadyear acadyear = db.acadyears.Find(id);
            db.acadyears.Remove(acadyear);
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
