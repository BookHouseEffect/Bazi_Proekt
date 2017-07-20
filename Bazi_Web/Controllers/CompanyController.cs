using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bazi_Business.Implementation;
using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Web.Models;
using Db201617zVaProektRnabContext;
using Bazi_Repository.Implementation;
using Bazi_Repository;

namespace Bazi_Web.Controllers
{
    [CustomAuthorize(Roles = "Company")]
    public class CompanyController : BaseController
    {
        AirplaneService AirplaneService;
        FlightService FlightService;

        public CompanyController()
        {
            this.AirplaneService = new AirplaneService();
            this.FlightService = new FlightService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewManagement manager = new ViewManagement();
            var a = manager.GetClassesWithMedianaTicketsByClass();
            var b = manager.GetCompaniesWithMaxProfit();
            var c = manager.GetPassengersThatFlightWithAllCompaniess();
            var d = manager.GetStatesWithMostFlights();
            var e = manager.PassengerThatSpentTheMost();

            return View(new CompanyIndexViewModel
            {
                A = a.ReturnedResult,
                B = b.ReturnedResult,
                C = c.ReturnedResult,
                D = d.ReturnedResult,
                E = e.ReturnedResult
            });
        }

        [HttpGet]
        public ActionResult ViewAirplanes(int pageNumber = 1, int pageSize = 10)
        {
            AirplaneListViewModel model = new AirplaneListViewModel { PageNumber = pageNumber, PageSize = pageSize };
            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
            if (comResponse.StatusCode != System.Net.HttpStatusCode.OK)
                return View(model);

            GetAirplaneListResponse response = AirplaneService.GetAirplaneList(new GetAirplanesListRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                CompanyId = comResponse.Company.KompanijaId
            });

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return View(model);

            model.Airplanes = response.Airplanes;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateAirplane(UpdateAirplaneViewModel model)
        {
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult AddFlight()
        {
            AddFlightViewModel model = new AddFlightViewModel();
            model.AirportsList = (new AirportManager()).GetAirportsList();

            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
            model.AirplaneList = comResponse.Company.Avionis_KompanijaId.ToList();

            return View(model);
        }

        [HttpPost]
        public String AddFlight(AddFlightPostModel model)
        {
            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });

            FlightManager flightManager = new FlightManager();
            RepoBaseResponse<Letovi> response = flightManager.AddNewFlight(new Bazi_Repository.RepositoryRequests.RepoAddNewFlightRequest
            {
                CompanyId = comResponse.Company.KompanijaId,
                SubFlightList = model.ListOfSubFlight,
                FlightDayList = model.ListOfDays,
                DeparturesTime = model.ListOfTimes
            });
            if (response.HasError()) return response.Message;

            ICollection<Megjuletovi> subflights = response.ReturnedResult.Megjuletovis_LetId.ToList();

            FlightSchemeManager fsmanager = new FlightSchemeManager();
            RepoBaseResponse<ICollection<PlanoviNaLetanje>> fsresponse = fsmanager.AddNewFlightScheme(
                new Bazi_Repository.RepositoryRequests.RepoAddNewFlightSchemeRequest
            {
                AirplaneId = model.AirplaneId,
                SubFlight = subflights,
                Status = "aktiven",
                StartDate = model.StartDate,
                EndDate = model.EndDate
            });
            if (fsresponse.HasError()) return fsresponse.Message;

            PriceManager pmanager = new PriceManager();
            List<Cenovnici> ceni = new List<Cenovnici>();
            foreach (PlanoviNaLetanje p in fsresponse.ReturnedResult)
            {
                int from = p.Megjuletovi_MegjuletId.AerodromOdId;
                int to = p.Megjuletovi_MegjuletId.AerodromDoId;
                
                foreach(var a in model.Prices)
                {
                    if (a.FromId == from && a.ToId == to)
                    {
                        Cenovnici c = new Cenovnici();
                        c.PlanId = p.PlanId;
                        c.KlasaId = a.ClassId;
                        c.CenaVoEdenPravec = a.OneWay;
                        c.CenaPovraten = a.Return;
                        ceni.Add(c);
                    }
                }
            }
            RepoBaseResponse<ICollection<Cenovnici>> presponce = pmanager.
                AddNewFlightPrice(new Bazi_Repository.RepositoryRequests.RepoAddNewFlightPriceRequest { PriceList = ceni });
            if (presponce.HasError()) return presponce.Message;

            return "Success";   
        }

        [HttpGet]
        public ActionResult ViewFlights(int pageNumber = 1, int pageSize = 10)
        {
            FlightListViewModel model = new FlightListViewModel { PageNumber = pageNumber, PageSize = pageSize };
            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
            if (comResponse.StatusCode != System.Net.HttpStatusCode.OK)
                return View(model);

            model.Flights = comResponse.Company.Letovis_KompanijaId.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            
            return View(model);
        }

        [HttpGet]
        public ActionResult RemoveFlight(int id)
        {
            FlightManager manager = new FlightManager();
            manager.RemoveFlightIfNotAssigned(new Bazi_Repository.RepositoryRequests.RepoRemoveFlightIfNotAssignedRequest { FlightId = id });
            return RedirectToAction("ViewFlights");
        }

        [HttpGet]
        public ActionResult RemoveSubFlight(int id)
        {
            SubFlightManager manager = new SubFlightManager();
            manager.RemoveSubFlightIfUnassigned(new Bazi_Repository.RepositoryRequests.RepoRemoveSubFlightIfUnassignedRequest { SubFlightId = id });
            return RedirectToAction("ViewFlights");
        }

        [HttpGet]
        public ActionResult ViewRealFlight(int id)
        {
            SubFlightManager manager = new SubFlightManager();
            RepoBaseResponse<Megjuletovi> response = manager.GetSubFlightById(new Bazi_Repository.RepositoryRequests.RepoGetSubFlightByIdRequest { SubFlightId = id });

            SchemeListViewModel model = new SchemeListViewModel();
            model.Schemes = response.ReturnedResult.PlanoviNaLetanjes_MegjuletId.ToList();

            return View(model);
        }
    }
}