using System.Web.Mvc;

namespace Bazi_Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}