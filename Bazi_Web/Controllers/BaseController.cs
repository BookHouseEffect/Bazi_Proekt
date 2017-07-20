using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bazi_Business.Implementation;

namespace Bazi_Web.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
        protected AccountService AccountService;

        public BaseController()
        {
            AccountService = new AccountService();
        }
    }
}