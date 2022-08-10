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
    public class subjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: subjects
        public ActionResult Index()
        {
            var subjects = db.subjects.Include(s => s.acadyear).Include(s => s.department).Include(s => s.user);
            return View(subjects.ToList());
        }

        // GET: subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }
        [Authorize]
        // GET: subjects/Create
        public ActionResult Create()
        {
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name");
            ViewBag.departmentid = new SelectList(db.departments, "id", "name");
            return View();
        }

        // POST: subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,departmentid,acadyearid,name,lecture,lab,credit,prerequest,date,userid")] subject subject)
        {
            if (ModelState.IsValid)
            {subject.userid= User.Identity.GetUserId();
                subject.date = DateTime.Now;
                db.subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", subject.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", subject.departmentid);
            return View(subject);
        }

        // GET: subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", subject.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", subject.departmentid);
            return View(subject);
        }

        // POST: subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,departmentid,acadyearid,name,lecture,lab,credit,prerequest,date,userid")] subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.userid = User.Identity.GetUserId();
                subject.date = DateTime.Now;
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", subject.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", subject.departmentid);
            return View(subject);
        }

        // GET: subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subject subject = db.subjects.Find(id);
            db.subjects.Remove(subject);
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
