using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi;

namespace WebApi.Controllers
{
    [Authorize]
    public class Student_has_CoursesController : Controller
    {
        private CourseEvalDB_WDEntities db = new CourseEvalDB_WDEntities();

        // GET: Student_has_Courses
        public ActionResult Index()
        {
            var student_has_Courses = db.Student_has_Courses.Include(s => s.Cours).Include(s => s.Student);
            return View(student_has_Courses.ToList());
        }

        // GET: Student_has_Courses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Courses student_has_Courses = db.Student_has_Courses.Find(id);
            if (student_has_Courses == null)
            {
                return HttpNotFound();
            }
            return View(student_has_Courses);
        }

        // GET: Student_has_Courses/Create
        public ActionResult Create()
        {
            ViewBag.Courses_courseID = new SelectList(db.Courses, "courseID", "Major_majorID");
            ViewBag.Student_stuID = new SelectList(db.Students, "stuID", "Major_majorID");
            return View();
        }

        // POST: Student_has_Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_stuID,Courses_courseID,question1,question2,question3,question4,question5,question6,question7,question8,question9,question10")] Student_has_Courses student_has_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Student_has_Courses.Add(student_has_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Courses_courseID = new SelectList(db.Courses, "courseID", "Major_majorID", student_has_Courses.Courses_courseID);
            ViewBag.Student_stuID = new SelectList(db.Students, "stuID", "Major_majorID", student_has_Courses.Student_stuID);
            return View(student_has_Courses);
        }

        // GET: Student_has_Courses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Courses student_has_Courses = db.Student_has_Courses.Find(id);
            if (student_has_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses_courseID = new SelectList(db.Courses, "courseID", "Major_majorID", student_has_Courses.Courses_courseID);
            ViewBag.Student_stuID = new SelectList(db.Students, "stuID", "Major_majorID", student_has_Courses.Student_stuID);
            return View(student_has_Courses);
        }

        // POST: Student_has_Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_stuID,Courses_courseID,question1,question2,question3,question4,question5,question6,question7,question8,question9,question10")] Student_has_Courses student_has_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_has_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses_courseID = new SelectList(db.Courses, "courseID", "Major_majorID", student_has_Courses.Courses_courseID);
            ViewBag.Student_stuID = new SelectList(db.Students, "stuID", "Major_majorID", student_has_Courses.Student_stuID);
            return View(student_has_Courses);
        }

        // GET: Student_has_Courses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Courses student_has_Courses = db.Student_has_Courses.Find(id);
            if (student_has_Courses == null)
            {
                return HttpNotFound();
            }
            return View(student_has_Courses);
        }

        // POST: Student_has_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student_has_Courses student_has_Courses = db.Student_has_Courses.Find(id);
            db.Student_has_Courses.Remove(student_has_Courses);
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
