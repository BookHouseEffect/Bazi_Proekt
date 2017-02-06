using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bazi_Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            if (User == null)
                return View();
            if (!User.Identity.IsAuthenticated)
                return View();
            if (User.IsInRole("Company"))
                RedirectToAction("Index", "Company");
            return View();
            
        }
    }
}