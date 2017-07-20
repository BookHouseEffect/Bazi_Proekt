using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bazi_Repository.Implementation;
using Bazi_Repository.RepositoryRequests;
using Bazi_Repository;
using Db201617zVaProektRnabContext;
using Bazi_Web.Models;
using Bazi_Business.Responses;

namespace Bazi_Web.Controllers
{
    public class PassengerController : BaseController
    {
        [CustomAuthorize(Roles = "Passenger")]
        public ActionResult Index(int? passengerId, int pageNumber=1, int pageSize=10)
        {
            GetPassengerInfoResponse response = AccountService.GetPassengerInfo(new Bazi_Business.Requests.GetPassengerInfoRequest { AccountId = User.UserId });

            TicketsManager manager = new TicketsManager();
            RepoBaseResponse<ICollection<Rezervacii>> tickets = manager.GetAllTicketsForPassenger(new RepoGetAllTicketsForPassengerRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                PassengerId = (passengerId.HasValue) ? passengerId.Value : response.Passengers.First().PatnikId
            });

            PassengerIndexModel model = new PassengerIndexModel
            {
                Passenger = response.Passengers,
                Tickets = tickets.ReturnedResult,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PassengerId = (passengerId.HasValue) ? passengerId.Value : response.Passengers.First().PatnikId
            };
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Passenger")]
        public ActionResult CancelTicket(int passengerId, int ticketId, int flightId)
        {
            TicketsManager manager = new TicketsManager();
            RepoBaseResponse<Rezervacii> response = manager.CancelTicket(new RepoCancelTicketRequest { FlightSchemeId = flightId, PassengerId = passengerId, TicketId = ticketId });

            return RedirectToAction("Index", "Passenger", new { passengerId = passengerId, pageNumber = 1, pageSize = 10 });
        }

        [HttpGet]
        public ActionResult Search()
        {
            AirportManager manager = new AirportManager();
            ICollection<Aerodromi> list = manager.GetAirportsList();

            SearchViewModel model = new SearchViewModel() { airports = list };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetFlights(SearchViewModel model)
        {
            SearchResultViewModel result = new SearchResultViewModel();
            SubFlightManager manager = new SubFlightManager();
            ICollection<Megjuletovi> subflight = manager.GetSubFlightByAirports(model.SourceAirport, model.DestinationAirport);

            List<PlanoviNaLetanje> plans = new List<PlanoviNaLetanje>();
            FlightSchemeManager fmanager = new FlightSchemeManager();
            foreach (Megjuletovi m in subflight) {
                RepoBaseResponse<ICollection<PlanoviNaLetanje>> plansres = fmanager.GetFlightSchemesBySubFlight(new RepoGetFlightSchemesBySubFlightRequest { SubflightId = m.MegjuletId, Date = model.Date });
                plans.AddRange(plansres.ReturnedResult);
            }
            result.flight = plans;
            return PartialView(result);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Passenger")]
        public ActionResult Reserve(int planId, int classId)
        {   
            return View(GetReservationModel(planId, classId));
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Passenger")]
        public ActionResult Reserve(ReservationViewModel model)
        {
            ReservationViewModel data = GetReservationModel(model.PlanId, model.ClassId);
            model.CurrentFlightScheme = data.CurrentFlightScheme;
            model.ReservedList = data.ReservedList;
            model.PassengerList = data.PassengerList;

            if (!ModelState.IsValid)
                return View(model);

            TicketsManager manager = new TicketsManager();

            Rezervacii ticket = new Rezervacii
                {
                    TipNaBilet = model.TicketType,
                    DatumNaIzdavanje = DateTime.Now,
                    PlatenaCena = (model.TicketType ?
                        model.CurrentFlightScheme.Cenovnicis_PlanId.Where(x => x.KlasaId == model.ClassId).First().CenaPovraten :
                        model.CurrentFlightScheme.Cenovnicis_PlanId.Where(x => x.KlasaId == model.ClassId).First().CenaVoEdenPravec)
                };
            if (model.TicketType)
                ticket.ValidenDo = DateTime.Now.AddMonths(3);

            RepoBaseResponse<Rezervacii> response = manager.AddNewTicket(new RepoAddNewTicketRequest
            {
                FlightScheme = model.CurrentFlightScheme,
                Passenger = model.PassengerList.Where(x => x.PatnikId == model.SelectedPassenger).Single(),
                Seat = new Sedishta { KlasaId = model.ClassId, BrojNaSediste = model.SeatNumber },
                Ticket = ticket
            });

            if (response.HasError())
                return View(model);

            return RedirectToAction("Index", "Passenger");
        }

        private ReservationViewModel GetReservationModel(int planId, int classId)
        {
            FlightSchemeManager fmanager = new FlightSchemeManager();
            RepoBaseResponse<PlanoviNaLetanje> p = fmanager.GetFlightSchemeById(new RepoGetFlightSchemeByIdRequest { FlightSchemeId = planId });

            ICollection<Rezervacii> r = p.ReturnedResult.Rezervaciis_PlanId;

            Bazi_Business.Responses.GetPassengerInfoResponse response = AccountService.GetPassengerInfo(new Bazi_Business.Requests.GetPassengerInfoRequest { AccountId = User.UserId });

            ReservationViewModel model = new ReservationViewModel { ClassId = classId, PlanId = planId, CurrentFlightScheme = p.ReturnedResult, ReservedList = r, PassengerList = response.Passengers };

            return model;
        }

        [HttpGet]
        public ActionResult Schedule(Int32? sourceAirport)
        {
            ScheduleViewModel model = new ScheduleViewModel();
            model.AirportList = (new AirportManager()).GetAirportsList();

            model.ScheduleList = new List<Rasporedi>();
            if (sourceAirport.HasValue)
            {
                model.SourceAirport = sourceAirport.Value;
                SubFlightManager manager = new SubFlightManager();
                ICollection<Megjuletovi> subflights = manager.GetSubFlightByAirports(sourceAirport.Value);
                foreach(Megjuletovi m in subflights)
                {
                    model.ScheduleList.AddRange(m.Rasporedis_MegjuletoviId.ToList());
                }
            }
            model.ScheduleList = model.ScheduleList.OrderBy(x => x.MegjuletoviId).ToList();

            return View(model);
        }
    }
}