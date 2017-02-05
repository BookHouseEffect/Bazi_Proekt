using Bazi_Business.Requests;
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
        public ActionResult Register(AccountTypes accountType = AccountTypes.PASSENGER)
        {
            RegisterViewModel model = new RegisterViewModel(accountType);

            if (User != null && User.Identity.IsAuthenticated) {
                if (!(accountType == AccountTypes.EMPLOYEE && User.IsInRole(Properties.Settings.Default.CompanyRole)))
                    return RedirectToAction("Index", "Home");
                return View(model);
            }
            if (!(accountType == AccountTypes.COMPANY || accountType == AccountTypes.PASSENGER))
                return RedirectToAction("Index", "Home");
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (User != null && User.Identity.IsAuthenticated) {
                if (!ModelState.IsValid) {
                    if (!(model.SelectedAccountType == AccountTypes.EMPLOYEE && User.IsInRole(Properties.Settings.Default.CompanyRole)))
                        return RedirectToAction("Index", "Home");
                    return View(model);
                }

                if (model.SelectedAccountType == AccountTypes.EMPLOYEE && User.IsInRole(Properties.Settings.Default.CompanyRole))
                {
                    EmployeeViewModel employeeModel = (EmployeeViewModel)model.Infomation;
                    RegisterEmployeeResponse employeeResponse =
                        AccountService.RegisterEmployee(new RegisterEmployeeRequest
                        {
                            EmployeeAccount = model.ParseToAkaunti(),
                            Person = employeeModel.ParseToLugje(),
                            Employee = employeeModel.ParseToVraboteni(),
                            CompanyAccountId = User.UserId,
                            Password = model.Password
                        });

                    if (employeeResponse.StatusCode != HttpStatusCode.OK)
                    {
                        ModelState.AddModelError(String.Empty, employeeResponse.Message);
                        return View(model);
                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid) {
                if (model.SelectedAccountType == AccountTypes.COMPANY || model.SelectedAccountType == AccountTypes.PASSENGER)
                    return View(model);
                return HttpNotFound();
            }

            if (model.SelectedAccountType == AccountTypes.COMPANY)
            {
                CompanyViewModel companyModel = (CompanyViewModel)model.Infomation;
                RegisterCompanyResponse companyResponse =
                    AccountService.RegisterCompany(new RegisterCompanyRequest
                    {
                        CompanyAccount = model.ParseToAkaunti(),
                        CompanyAddress = companyModel.Address.ParseToAdresi(),
                        Company = companyModel.ParseToAviokompanii(),
                        Password = model.Password
                    });

                if (companyResponse.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError(String.Empty, companyResponse.Message);
                    return View(model);
                }
                else
                    return RedirectToAction("Login");
            }
            if (model.SelectedAccountType == AccountTypes.PASSENGER)
            {
                PassengersViewModel passengerModel = (PassengersViewModel)model.Infomation;
                RegisterPassengerResponse passengerResponse =
                    AccountService.RegisterPassenger(new RegisterPassengerRequest
                    {
                        PassengerAccount = model.ParseToAkaunti(),
                        PassengerAddress = passengerModel.Address.ParseToAdresi(),
                        Person = passengerModel.ParseToLugje(),
                        Passenger = passengerModel.ParseToPatnici(),
                        Password = model.Password
                    });

                if (passengerResponse.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError(String.Empty, passengerResponse.Message);
                    return View(model);
                }
                else
                    return RedirectToAction("Login");
            }
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
            } else if (serializeModel.Roles.Any(r => r.Contains(Properties.Settings.Default.CompanyRole))) {
                return RedirectToAction("", ""); //TODO Redirect to company Panel
            } else if (serializeModel.Roles.Any(r => r.Contains(Properties.Settings.Default.EmployeeRole))) {
                return RedirectToAction("", ""); //TODO Redirect to worker Panel
            } else
                return RedirectToAction("", ""); //TODO Redirect to error 500 page Panel.
        }

        [HttpGet]
        public ActionResult AccountSettings()
        {
            if (User == null || User.Identity == null || !User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            EditViewModel model;
            if (User.IsInRole(Properties.Settings.Default.PassengerRole)) {
                GetPassengerInfoResponse response = AccountService.GetPassengerInfo(new GetPassengerInfoRequest { AccountId = User.UserId });
                if (response.StatusCode != HttpStatusCode.OK)
                    throw response.Exception;
                model = new EditViewModel(response.Passengers);
            } else if (User.IsInRole(Properties.Settings.Default.CompanyRole)) {
                GetCompanyInfoResponse response = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
                if (response.StatusCode != HttpStatusCode.OK)
                    throw response.Exception;
                model = new EditViewModel(response.Company);
            } else if (User.IsInRole(Properties.Settings.Default.EmployeeRole)) {
                model = new EditViewModel() { SelectedAccountType = AccountTypes.EMPLOYEE };
            } else
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Company,Employee,Passenger")]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);
            ChangePasswordResponse response = 
                AccountService.ChangePassword(new ChangePasswordRequest
                {
                    AccoundId = User.UserId,
                    OldPassword = model.OldPassword,
                    NewPassword = model.NewPassword
                });
            if (response.StatusCode != HttpStatusCode.OK)
                ModelState.AddModelError(String.Empty, response.Message);
            else ViewBag.Message = response.Message;
            return PartialView(model);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Company")]
        public ActionResult UpdateCompany(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            UpdateCompanyResponse  response = AccountService.UpdateCompany(new UpdateCompanyRequest
            {
                AkauntId = User.UserId,
                CompanyId = model.CompanyId,
                Company = model.ParseToAviokompanii(),
                Address = model.Address.ParseToAdresi()
            });

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ModelState.AddModelError(String.Empty, response.Message);
                return PartialView(model);
            }
            else
            {
                ViewBag.Message = response.Message;
                return PartialView(new CompanyViewModel(response.Company));
            }
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Passenger")]
        public ActionResult UpdatePassenger(PassengersViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            UpdatePassengerResponse response = AccountService.UpdatePassenger(new UpdatePassengerRequest
            {
                AkauntId = User.UserId,
                PassengerId = model.PassengerId,
                Passenger = model.ParseToPatnici(),
                Person = model.ParseToLugje(),
                Address = model.Address.ParseToAdresi()
            });

            if (response.StatusCode != HttpStatusCode.OK) {
                ModelState.AddModelError(String.Empty, response.Message);
                return PartialView(model);
            }
            else
            {
                ViewBag.Message = response.Message;
                return PartialView(new PassengersViewModel(response.Passenger));
            }
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
    }
}