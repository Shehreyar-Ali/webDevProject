using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class stuHomeController : Controller
    {
        // GET: stuHome
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View();
        }


    }
}