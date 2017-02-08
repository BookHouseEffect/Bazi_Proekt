using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bazi_Business.Implementation;
using Bazi_Business.Requests;
using Bazi_Business.Responses;
using System.Net;
using Bazi_Web.Models;
using Db201617zVaProektRnabContext;
using Bazi_Repository.Implementation;

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
            return View();
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
            return View(new AddFlightViewModel());
        }

        [HttpPost]
        public ActionResult AddFlight(AddFlightViewModel model)
        {
            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
            FlightManager flightManager = new FlightManager();
            flightManager.AddNewFlight(new Bazi_Repository.RepositoryRequests.RepoAddNewFlightRequest
            {
                CompanyId = comResponse.Company.KompanijaId,
                SubFlightList = model.ListOfFlights,
                FlightDayList = model.DepartureDays,
                DeparturesTime = model.DepartureTime
            });

            return RedirectToAction("Index", "Company");
        }


        public ActionResult SubFlight(Int32 Index)
        {
            Airports model = new Airports
            {
                Number = Index
                //Airs = (new AirportManager()).GetAirports()
            };
            return PartialView(model);
        }

        public ActionResult Departure(Int32 Index)
        {
            return PartialView(model: Index);
        }

        [HttpGet]
        public ActionResult ViewFlights(int pageNumber = 1, int pageSize = 10)
        {
            FlightListViewModel model = new FlightListViewModel { PageNumber = pageNumber, PageSize = pageSize };
            GetCompanyInfoResponse comResponse = AccountService.GetComapnyInfo(new GetCompanyInfoRequest { AccountId = User.UserId });
            if (comResponse.StatusCode != System.Net.HttpStatusCode.OK)
                return View(model);

            GetFlightListResponse response = FlightService.GetFlightList(new GetFlightListRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                CompanyId = comResponse.Company.KompanijaId
            });

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return View(model);

            model.Flights = response.Flights;
            return View(model);
        }
    }
}