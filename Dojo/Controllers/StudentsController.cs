using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dojo.Models;

namespace Dojo.Controllers
{
    public class StudentsController : Controller
    {
        private AdtProjectEntities4 db = new AdtProjectEntities4();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Membership).Include(s => s.Rank);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Membership_ID = new SelectList(db.Memberships, "Membership_ID", "Name");
            ViewBag.Rank_ID = new SelectList(db.Ranks, "Rank_ID", "Title");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STUDENT_ID,STUDENT_Fname,STUDENT_Lname,STUDENT_DOB,StreetName,Town,PostalCode,PhoneNumber,email,DateJoined,Membership_ID,IsActive,IsParent,Rank_ID,Parent_ID,AttendanceCount")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Membership_ID = new SelectList(db.Memberships, "Membership_ID", "Name", student.Membership_ID);
            ViewBag.Rank_ID = new SelectList(db.Ranks, "Rank_ID", "Title", student.Rank_ID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Membership_ID = new SelectList(db.Memberships, "Membership_ID", "Name", student.Membership_ID);
            ViewBag.Rank_ID = new SelectList(db.Ranks, "Rank_ID", "Title", student.Rank_ID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STUDENT_ID,STUDENT_Fname,STUDENT_Lname,STUDENT_DOB,StreetName,Town,PostalCode,PhoneNumber,email,DateJoined,Membership_ID,IsActive,IsParent,Rank_ID,Parent_ID,AttendanceCount")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Membership_ID = new SelectList(db.Memberships, "Membership_ID", "Name", student.Membership_ID);
            ViewBag.Rank_ID = new SelectList(db.Ranks, "Rank_ID", "Title", student.Rank_ID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
