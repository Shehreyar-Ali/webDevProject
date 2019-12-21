using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //return "Hello World";
            return View();
        }

        public ActionResult Test()
        {
            //return "testing, testing.....1, 2, 3";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(StuMember StLogin)
        {
            using (var context = new CourseEvalDB_WDEntities())
            {
                bool isValid = context.Students.Any(stu => stu.loginStu == StLogin.loginStu && stu.passwordStu == StLogin.passwordStu);
                if (isValid)
                {
                    return RedirectToAction("Index", "Student_has_Courses");
                }
                ModelState.AddModelError("", "Invalid Username and password");
                return View();
            }
                return View();
        }

    }
}