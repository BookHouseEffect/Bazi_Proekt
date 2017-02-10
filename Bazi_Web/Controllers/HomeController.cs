using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bazi_Repository.Implementation;

namespace Bazi_Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            Bazi_Repository.RepoBaseResponse<ICollection<Brojac>> response = (new ViewManagement()).GetCounter();

            if (User == null)
                return View(response.ReturnedResult);
            if (!User.Identity.IsAuthenticated)
                return View(response.ReturnedResult);
            if (User.IsInRole("Company"))
                return RedirectToAction("Index", "Company");
            if (User.IsInRole("Passenger"))
                return RedirectToAction("Index", "Passenger");

            return View(response.ReturnedResult);
        }
    }
}