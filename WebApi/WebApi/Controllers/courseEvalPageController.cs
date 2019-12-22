using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class courseEvalPageController : Controller
    {
        // GET: courseEvalPage
        [OutputCache(Duration = 60)]
        public ActionResult Index(string id)
        {
            string lol = id;
            Session["courseid"] = id;
                return View();
        }
        [HttpPost]
        public ActionResult Index(CourseEval crsform)
        {
            var cid = Session["courseid"];
            var Uid = User.Identity.Name;

            ViewBag.Cid = cid;
            ViewBag.Stdid = Uid;

            using (var context = new CourseEvalDB_WDEntities())
            {
                var Stdnt = context.Students.First(x => x.loginStu == Uid);
                string StudentID = Stdnt.stuID;
                WebApi.Student_has_Courses StrCrs = context.Student_has_Courses.First(x => x.Courses_courseID == (string)cid && x.Student_stuID == StudentID);
                StrCrs.Courses_courseID = (string)cid;
                StrCrs.Student_stuID = StudentID;
                StrCrs.question1 = crsform.question1;
                StrCrs.question2 = crsform.question2;
                StrCrs.question3 = crsform.question3;
                StrCrs.question4 = crsform.question4;
                StrCrs.question5 = crsform.question5;
                StrCrs.question6 = crsform.question6;
                StrCrs.question7 = crsform.question7;
                StrCrs.question8 = crsform.question8;
                StrCrs.question9 = crsform.question9;
                StrCrs.question10 = crsform.question10;

                context.SaveChanges();
            }

            return RedirectToAction("Index", "stuHome");

        }





    }
}