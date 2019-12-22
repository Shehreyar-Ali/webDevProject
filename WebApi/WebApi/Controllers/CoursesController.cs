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
    public class CoursesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Home()
        {
            var Username = User.Identity.Name;

            using (var context = new CourseEvalDB_WDEntities())
            {
                var Stdnts = context.Students.Where(st => st.loginStu == Username);
                IEnumerable<WebApi.Student_has_Courses> stdntCourses = null;
                foreach (var stdnt in Stdnts)
                {
                    stdntCourses = context.Student_has_Courses.Where(c => c.Student_stuID == stdnt.stuID);
                }
                IEnumerable<WebApi.Cours> Courses = null;
                IEnumerable<Courses> RetCourses = new Courses[0];
                foreach (var stdntCourse in stdntCourses)
                {
                    if (Courses == null)
                    {
                        Courses = context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID);
                    }
                    else
                    {
                        Courses = Courses.Concat(context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID));
                    }
                }

                foreach (var c in Courses)
                {
                    Courses rc = new Courses();
                    rc.courseID = c.courseID;
                    rc.courseInstructor = c.courseInstructor;
                    rc.courseName = c.courseName;
                    rc.Major_majorID = c.Major_majorID;
                    RetCourses = RetCourses.Concat(new[] { rc });
                }
                Console.WriteLine("HEllo");
                Console.WriteLine(RetCourses);
                return Ok(RetCourses);

            }
        }

        [HttpGet]
        public IHttpActionResult EvalsDone()
        {
            var Username = User.Identity.Name;

            using (var context = new CourseEvalDB_WDEntities())
            {
                var Stdnts = context.Students.Where(st => st.loginStu == Username);
                IEnumerable<WebApi.Student_has_Courses> stdntCourses = null;
                foreach (var stdnt in Stdnts)
                {
                    stdntCourses = context.Student_has_Courses.Where(c => c.Student_stuID == stdnt.stuID && c.question1 != null && c.question2 != null && c.question3 != null && c.question4 != null && c.question5 != null && c.question6 != null && c.question7 != null && c.question8 != null && c.question9 != null && c.question10 != null);
                }
                IEnumerable<WebApi.Cours> Courses = null;
                IEnumerable<Courses> RetCourses = new Courses[0];
                foreach (var stdntCourse in stdntCourses)
                {
                    if (Courses == null)
                    {
                        Courses = context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID);
                    }
                    else
                    {
                        Courses = Courses.Concat(context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID));
                    }
                }

                if (Courses == null)
                {
                    String NC = "No Courses";
                    return Ok(NC);
                }

                foreach (var c in Courses)
                {
                    Courses rc = new Courses();
                    rc.courseID = c.courseID;
                    rc.courseInstructor = c.courseInstructor;
                    rc.courseName = c.courseName;
                    rc.Major_majorID = c.Major_majorID;
                    RetCourses = RetCourses.Concat(new[] { rc });
                }
                Console.WriteLine("HEllo");
                Console.WriteLine(RetCourses);
                return Ok(RetCourses);

            }
        }

        [HttpGet]
        public IHttpActionResult Evalsleft()
        {
            var Username = User.Identity.Name;

            using (var context = new CourseEvalDB_WDEntities())
            {
                var Stdnts = context.Students.Where(st => st.loginStu == Username);
                IEnumerable<WebApi.Student_has_Courses> stdntCourses = null;
                foreach (var stdnt in Stdnts)
                {
                    stdntCourses = context.Student_has_Courses.Where(c => c.Student_stuID == stdnt.stuID && (c.question1 == null || c.question2 == null || c.question3 == null | c.question4 == null || c.question5 == null || c.question6 == null || c.question7 == null || c.question8 == null || c.question9 == null || c.question10 == null));
                }
                IEnumerable<WebApi.Cours> Courses = null;
                IEnumerable<Courses> RetCourses = new Courses[0];
                foreach (var stdntCourse in stdntCourses)
                {
                    if (Courses == null)
                    {
                        Courses = context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID);
                    }
                    else
                    {
                        Courses = Courses.Concat(context.Courses.Where(crs => crs.courseID == stdntCourse.Courses_courseID));
                    }
                }

                if (Courses == null)
                {
                    String NC = "No Courses";
                    return Ok(NC);
                }

                foreach (var c in Courses)
                {
                    Courses rc = new Courses();
                    rc.courseID = c.courseID;
                    rc.courseInstructor = c.courseInstructor;
                    rc.courseName = c.courseName;
                    rc.Major_majorID = c.Major_majorID;
                    RetCourses = RetCourses.Concat(new[] { rc });
                }
                Console.WriteLine("HEllo");
                Console.WriteLine(RetCourses);
                return Ok(RetCourses);

            }
        }





    }
}
