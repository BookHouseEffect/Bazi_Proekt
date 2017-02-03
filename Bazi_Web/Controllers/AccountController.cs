﻿using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Web.Models;
using Db201617zVaProektRnabContext;
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
            if (User != null && User.Identity.IsAuthenticated) {
                if (accountType == AccountTypes.EMPLOYEE && User.IsInRole("Company"))
                    return View(new EmployeeViewModel() { SelectedAccountType = accountType });
                return Redirect("~/");
            }
            if (accountType == AccountTypes.COMPANY)
                return View(new CompanyViewModel() { SelectedAccountType = accountType });
            if (accountType == AccountTypes.PASSENGER)
                return View(new PassengersViewModel() { SelectedAccountType = accountType });
            return Redirect("~/");
        }

        [HttpPost]
        public ActionResult Register(AccountBaseModel model)
        {
            RegisterViewModel submodel = (RegisterViewModel)model;
            if (User != null && User.Identity.IsAuthenticated) {
                if (!ModelState.IsValid){
                    if(submodel.SelectedAccountType == AccountTypes.EMPLOYEE)
                        return View((EmployeeViewModel)model);
                    return Redirect("~/");
                }

                //TODO employe registration
                if (submodel.SelectedAccountType == AccountTypes.EMPLOYEE)
                    return View((EmployeeViewModel)model);
                return Redirect("~/");
            }

            if (!ModelState.IsValid) {
                if (submodel.SelectedAccountType == AccountTypes.COMPANY)
                    return View((CompanyViewModel)model);
                if (submodel.SelectedAccountType == AccountTypes.PASSENGER)
                    return View((PassengersViewModel)model);
                return HttpNotFound();
            }

            //TODO perform company, passenger registration
            if (submodel.SelectedAccountType == AccountTypes.COMPANY)
            {
                CompanyViewModel companyModel = (CompanyViewModel)model;
                RegisterCompanyResponse companyResponse = 
                    AccountService.RegisterCompany(new RegisterCompanyRequest
                    {
                        CompanyAccount = companyModel.ParseToAkaunti(),
                        CompanyAddress = companyModel.Address.ParseToAdresi(),
                        Company = companyModel.ParseToAviokompanii(),
                        Password = companyModel.Password
                    });

                if (companyResponse.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError(String.Empty, companyResponse.Message);
                    return View(model);
                }
                else
                    return RedirectToAction("Login");
            }
            if (submodel.SelectedAccountType == AccountTypes.PASSENGER)
                return View((PassengersViewModel)model);
            return HttpNotFound();
        } 

        [HttpGet]
        public ActionResult LogIn()
        {
            if (User != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (User != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

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