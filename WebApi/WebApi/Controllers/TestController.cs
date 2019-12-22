using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< HEAD
using System.Web.Security;
=======
>>>>>>> 62e4a03d3d2b731238964c87584b32058453959f
=======
>>>>>>> 62e4a03d3d2b731238964c87584b32058453959f
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
<<<<<<< HEAD
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Test");
        }

        [HttpPost]
        public ActionResult Login(Member User)
        {
            using (var context = new CourseEvalDB_WDEntities())
            {
                bool isvalid = context.Students.Any(x => x.loginStu == User.loginStu && x.passwordStu == User.passwordStu);
                var item = context.Students.FirstOrDefault(i => i.loginStu == "rk111");
                if (item != null)
                {
                    Console.WriteLine("No such item exists");
                }
                else
                {
                    Console.WriteLine(item.passwordStu);
                }
                if (isvalid == true)
                {
                    FormsAuthentication.SetAuthCookie(User.loginStu, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username and password");
                    return View();
                }

            }
        }



=======
=======
>>>>>>> 62e4a03d3d2b731238964c87584b32058453959f
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
>>>>>>> 62e4a03d3d2b731238964c87584b32058453959f
=======
>>>>>>> 62e4a03d3d2b731238964c87584b32058453959f
>>>>>>> Stashed changes
    }
}