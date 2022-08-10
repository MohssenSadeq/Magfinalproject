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
using System.IO;

namespace Magfinalproject.Controllers
{
    public class studentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.acadyear).Include(s => s.department).Include(s => s.user);
            return View(students.ToList());
        }

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [Authorize]
        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name");
            ViewBag.departmentid = new SelectList(db.departments, "id", "name");
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student student, HttpPostedFileBase upload)
        {
            var name = Convert.ToString(DateTime.Now.Millisecond);
            var m = name + Path.GetFileName(upload.FileName);
            string path = Path.Combine(Server.MapPath("~/uploads"), m);
            upload.SaveAs(path);
            student.photo = m;
            if (ModelState.IsValid)
            {
                student.userid= User.Identity.GetUserId();
                student.date = DateTime.Now;
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", student.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", student.departmentid);
            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", student.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", student.departmentid);
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(student student, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null)
                {
                    var name = Convert.ToString(DateTime.Now.Millisecond);
                    var m = name + Path.GetFileName(upload.FileName);
                    string old = Path.Combine(Server.MapPath("~/uploads"), student.photo);
                    System.IO.File.Delete(old);
                    string path = Path.Combine(Server.MapPath("~/uploads"), m);
                    upload.SaveAs(path);
                    student.photo = m;

                }
                student.userid = User.Identity.GetUserId();
                student.date = DateTime.Now;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", student.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", student.departmentid);
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            string old = Path.Combine(Server.MapPath("~/uploads"), student.photo);
            System.IO.File.Delete(old);
            db.students.Remove(student);
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
