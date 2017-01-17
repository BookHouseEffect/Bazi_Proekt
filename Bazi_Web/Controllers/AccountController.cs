using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Repository.Implementation;
using Bazi_Web.Models;
using Db201617zVaProektRnabContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bazi_Web.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /*TODO Requires a model*/
        //[HttpPost]
        //public ActionResult Register(SignUpViewModel model)
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            LogInResponse response = AccountService.LogIn(
                new LogInRequest { Username = model.Username, Password = model.Password });
            if (response.StatusCode != HttpStatusCode.OK) {
                ModelState.AddModelError(String.Empty, response.Message);
                return View(model);
            }

            CustomePrincipalSerializeModel serializeModel = new CustomePrincipalSerializeModel(response.Account);
            string userData = JsonConvert.SerializeObject(serializeModel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1, response.Account.KorisnichkoIme, DateTime.Now, DateTime.Now.AddMinutes(30), model.RememberMe, userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
 
            if (serializeModel.Roles.Any(r => r.Contains(Properties.Settings.Default.PassengerRole))) {
                return RedirectToAction("", ""); //TODO Redirect to passenger Panel
            } else if (serializeModel.Roles.Any(r => r.Contains(Properties.Settings.Default.EmployerRole))){
                return RedirectToAction("", ""); //TODO Redirect to company Panel
            } else if (serializeModel.Roles.Any(r => r.Contains(Properties.Settings.Default.EmployeeRole))){
                return RedirectToAction("", ""); //TODO Redirect to worker Panel
            } else
                return RedirectToAction("", ""); //TODO Redirect to error 500 page Panel.
        }
    }
}