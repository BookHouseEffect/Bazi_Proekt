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

namespace Bazi_Web.Controllers
{
    [CustomAuthorize(Roles = "Company")]
    public class CompanyController : BaseController
    {
        AirplaneService AirplaneService;

        public CompanyController()
        {
            this.AirplaneService = new AirplaneService();
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
    }
}