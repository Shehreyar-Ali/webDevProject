using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using System.Web.Security;
using System.Globalization;
using System.Web.SessionState;

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
                    Session["Username"] = User.loginStu;
                    FormsAuthentication.SetAuthCookie(User.loginStu, false);
                    return RedirectToAction("Index", "stuHome");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username and password");
                    return View();
                }

            }
        }

    }
}