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
    public class marksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: marks
        public ActionResult Index()
        {
            var marks = db.marks.Include(m => m.acadyear).Include(m => m.department).Include(m => m.student).Include(m => m.subject).Include(m => m.user);
            return View(marks.ToList());
        }

        // GET: marks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }
        [Authorize]
        public ActionResult Createo()
        {
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name");
            ViewBag.departmentid = new SelectList(db.departments, "id", "name");
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createo([Bind(Include = "id,departmentid,acadyearid,subjectid,studentid,sess,exam,grade,state,note,date,userid")] mark mark)
        {
           
              
                return RedirectToAction("Create",new { deparid=mark.departmentid, classid =mark.acadyearid});
            

           
        }
        [Authorize]
        // GET: marks/Create
        public ActionResult Create(int? deparid, int? classid)
        {
            ViewBag.acadyearid = new SelectList(db.acadyears.Where(a => a.id==classid) , "id", "name");
            ViewBag.departmentid = new SelectList(db.departments.Where(a=> a.id ==deparid), "id", "name");
            ViewBag.studentid = new SelectList(db.students.Where(a=> a.departmentid==deparid&& a.acadyearid==classid), "id", "stuid");
            ViewBag.subjectid = new SelectList(db.subjects.Where(a => a.departmentid == deparid && a.acadyearid == classid), "id", "name");
            return View();
        }

        // POST: marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,departmentid,acadyearid,subjectid,studentid,sess,exam,grade,state,note,date,userid")] mark mark)
        {
            if (ModelState.IsValid)
            {
                mark.userid= User.Identity.GetUserId();
                mark.date = DateTime.Now;
                db.marks.Add(mark);
                db.SaveChanges();
                TempData.Clear();
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }

            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", mark.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", mark.departmentid);
            ViewBag.studentid = new SelectList(db.students, "id", "stuid", mark.studentid);
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", mark.subjectid);
            return View(mark);
        }

        // GET: marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", mark.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", mark.departmentid);
            ViewBag.studentid = new SelectList(db.students, "id", "stuid", mark.studentid);
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", mark.subjectid);
            return View(mark);
        }

        // POST: marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,departmentid,acadyearid,subjectid,studentid,sess,exam,grade,state,note,date,userid")] mark mark)
        {
            if (ModelState.IsValid)
            {
                mark.userid = User.Identity.GetUserId();
                mark.date = DateTime.Now;
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                TempData.Clear();
                TempData["Edit"] = "Edit";
                return RedirectToAction("Index");
            }
            ViewBag.acadyearid = new SelectList(db.acadyears, "id", "name", mark.acadyearid);
            ViewBag.departmentid = new SelectList(db.departments, "id", "name", mark.departmentid);
            ViewBag.studentid = new SelectList(db.students, "id", "stuid", mark.studentid);
            ViewBag.subjectid = new SelectList(db.subjects, "id", "name", mark.subjectid);
            return View(mark);
        }

        // GET: marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mark mark = db.marks.Find(id);
            db.marks.Remove(mark);
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
