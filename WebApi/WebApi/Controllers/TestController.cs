using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}