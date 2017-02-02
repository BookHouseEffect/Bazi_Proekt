using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Web.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bazi_Web.Controllers
{
    public class AccountController : BaseController
    {
        public enum AccountTypes { PASSENGER, COMPANY, EMPLOYEE }

        [HttpGet]
        public ActionResult Register(AccountTypes accountType)
        {
            //TODO don't allow account registration for signed users, except for company
            switch (accountType)
            {
                case AccountTypes.PASSENGER:
                    return View(new PassengersViewModel() { SelectedAccountType = accountType });
                case AccountTypes.EMPLOYEE:
                    if (User.Roles.Contains("Company"))
                        return View(new EmployeeViewModel() { SelectedAccountType = accountType });
                    else
                        return Redirect("~/"); //TODO redirect to forbidden
                case AccountTypes.COMPANY:
                    return View(new CompanyViewModel() { SelectedAccountType = accountType });
                default:
                    return Redirect("~/"); //TODO Redirect to not found page
            }

        }

        [HttpPost]
        public ActionResult Register(AccountBaseModel model)
        {
            if (!ModelState.IsValid)
            {
                switch (((RegisterViewModel)model).SelectedAccountType)
                {
                    case AccountTypes.PASSENGER: return View((PassengersViewModel)model);
                    case AccountTypes.EMPLOYEE:
                        if (User.Roles.Contains("Company"))
                            return View((EmployeeViewModel)model);
                        else return Redirect("~/"); //TODO redirect to forbidden
                    case AccountTypes.COMPANY:
                        return View((CompanyViewModel) model);
                    default:
                        return Redirect("~/"); //TODO Redirect to not found page
                }
            }

            //TODO Perform registration Process
            switch (((RegisterViewModel)model).SelectedAccountType)
            {
                case AccountTypes.PASSENGER: return View((PassengersViewModel)model);
                case AccountTypes.EMPLOYEE:
                    if (User.Roles.Contains("Company"))
                        return View((EmployeeViewModel)model);
                    else return Redirect("~/"); //TODO redirect to forbidden
                case AccountTypes.COMPANY:
                    return View((CompanyViewModel)model);
                default:
                    return Redirect("~/"); //TODO Redirect to not found page
            }
        } 

        [HttpGet]
        public ActionResult LogIn()
        {
            //TODO check if the user is already logged in before showing the login form
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            //TODO do not allow login if the user is already logged
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

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home", null);
        }

        [HttpGet]
        public JsonResult Address(string attributeName, string attributeValue)
        {

            return new JsonResult();
        }
    }
}