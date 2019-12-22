using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using System.Web.Security;
using System.Web;
using System.Web.SessionState;
using System.Linq;
using System.Xml.Linq;

namespace WebApi.Controllers
{
    //[Authorize]
    public class CoursController : ApiController
    {
        private CourseEvalDB_WDEntities db = new CourseEvalDB_WDEntities();

        // GET: api/Cours
        public IQueryable<Cours> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult GetCours(string id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            return Ok(cours);
        }

        // PUT: api/Cours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCours(string id, Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cours.courseID)
            {
                return BadRequest();
            }

            db.Entry(cours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cours
        [ResponseType(typeof(Cours))]
        public IHttpActionResult PostCours(Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(cours);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CoursExists(cours.courseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cours.courseID }, cours);
        }


        [ResponseType(typeof(Cours))]
        public IHttpActionResult Home()
        {
            var Username = HttpContext.Current.Session["Username"];

            Username = (String)Username;
            using (var context = new CourseEvalDB_WDEntities())
            {
                var Stdnts = context.Students.Where(st => st.loginStu == Username);
                IEnumerable<WebApi.Student_has_Courses> stdntCourses = null;
                foreach (var stdnt in Stdnts)
                {
                    stdntCourses = context.Student_has_Courses.Where(c => c.Student_stuID == stdnt.stuID);
                }
                IEnumerable<WebApi.Cours> Courses = null;

                foreach (var stdntCourse in stdntCourses)
                {
                    Courses.Concat(context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID));
                }
                Console.WriteLine("HEllo");
                Console.WriteLine(Courses);
                return Ok(Courses);

            }

        }

        // DELETE: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult DeleteCours(string id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.Courses.Remove(cours);
            db.SaveChanges();

            return Ok(cours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursExists(string id)
        {
            return db.Courses.Count(e => e.courseID == id) > 0;
        }
    }
}