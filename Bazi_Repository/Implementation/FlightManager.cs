using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class FlightManager : BaseManager, IFlightManager
    {
        private Letovi GetById(int id)
        {
            return Context.Letovi.Where(x => x.LetId == id).SingleOrDefault();
        }

        public RepoBaseResponse<Letovi> AddNewFlight(RepoAddNewFlightRequest request)
        {
            RepoBaseResponse<Letovi> response = new RepoBaseResponse<Letovi>();

            FlightDaysManager flightDaysManager = new FlightDaysManager(this.Context);
            RepoBaseResponse<ICollection<DenoviNaLetanje>> flightDaysResponse = null;

            SubFlightManager subFlightManager = new SubFlightManager(this.Context);
            RepoBaseResponse<ICollection<Megjuletovi>> subFlightsResponse = null;

            ScheduleManager scheduleManager = new ScheduleManager(this.Context);
            RepoBaseResponse<ICollection<Rasporedi>> scheduleResponse = null;

            try
            {
                Letovi flight = new Letovi() { KompanijaId = request.CompanyId, Status = "aktiven" };
                Context.Letovi.InsertOnSubmit(flight);
                Context.SubmitChanges();

                flightDaysResponse = flightDaysManager.AssignFlightDays(new RepoAssignFlightDaysRequest { FlightId = flight.LetId, FlightDayList = request.FlightDayList });
                if (flightDaysResponse.HasError()) throw flightDaysResponse.Exception;

                subFlightsResponse = subFlightManager.AddNewSubFlights(
                    new RepoAddNewSubFlightsRequest { SubFlights = request.SubFlightList, FlightId = flight.LetId });
                if (subFlightsResponse.HasError()) throw subFlightsResponse.Exception;

                scheduleResponse = scheduleManager.AddNewSchedule(
                    new RepoAddNewScheduleRequest { SubFlights = subFlightsResponse.ReturnedResult, DeparturesTime = request.DeparturesTime,
                        FlightDayList = request.FlightDayList, RequiredWaitingInterval = new TimeSpan(0, 30, 0)});
                if (scheduleResponse.HasError()) throw scheduleResponse.Exception;

                response.ReturnedResult = flight;

            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);

                //TODO Perform roll back operation
            }
            return response;
        }

        public RepoBaseResponse<Letovi> GetFlightById(RepoGetFlightByIdRequest request)
        {
            RepoBaseResponse<Letovi> response = new RepoBaseResponse<Letovi>();
            try
            {
                response.ReturnedResult = GetById(request.FlightId);
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Letovi> RemoveFlightIfNotAssigned(RepoRemoveFlightIfNotAssignedRequest request)
        {
            RepoBaseResponse<Letovi> response = new RepoBaseResponse<Letovi>();
            try
            {
                Letovi flight = GetById(request.FlightId);
                if (flight == null)
                    throw new Exception("The flight does not exist");

                if (flight.Megjuletovis_LetId.Count != 0)
                    throw new Exception("The flight is not deletable");

                if (flight.DenoviNaLetanjes_LetId.Count != 0) {
                    FlightDaysManager mng = new FlightDaysManager(this.Context);
                    mng.RemoveFlightDays(new RepoRemoveFlightDaysRequest() { FlightId = request.FlightId });
                }

                this.Context.Letovi.DeleteOnSubmit(flight);
                Context.SubmitChanges();
                response.ReturnedResult = flight;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
