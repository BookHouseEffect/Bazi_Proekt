using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class TicketsManager : BaseManager, ITicketsManager
    {
        public RepoBaseResponse<Rezervacii> AddNewTicket(RepoAddNewTicketRequest request)
        {
            RepoBaseResponse<Rezervacii> response = new RepoBaseResponse<Rezervacii>();
            SeatsManager seatsManager = new SeatsManager(this.Context);
            try
            {
                request.Ticket.PlanId = request.FlightScheme.PlanId;
                request.Ticket.PatnikId = request.Passenger.PatnikId;

                RepoBaseResponse<Sedishta> seatResponse = seatsManager.AddNewSeat(
                    new RepoAddNewSeatRequest { ClassId = request.Seat.KlasaId, SeatNumber = request.Seat.BrojNaSediste });
                if (seatResponse.HasError()) throw seatResponse.Exception;

                request.Ticket.SedishteId = seatResponse.ReturnedResult.SedishteId;

                Context.Rezervacii.InsertOnSubmit(request.Ticket);
                Context.SubmitChanges();
                response.ReturnedResult = request.Ticket;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Rezervacii> CancelTicket(RepoCancelTicketRequest request)
        {
            RepoBaseResponse<Rezervacii> response = new RepoBaseResponse<Rezervacii>();
            try
            {
                Rezervacii ticket = Context.Rezervacii.Where(x => x.BiletId == request.TicketId && x.PatnikId == request.PassengerId && x.PlanId == request.FlightSchemeId).SingleOrDefault();
                Context.Rezervacii.DeleteOnSubmit(ticket);
                Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Rezervacii> ExtendTicket(RepoExtendTicketRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Rezervacii>> GetAllTicketsForFlightScheme(RepoGetAllTicketsForFlightSchemeRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Rezervacii>> GetAllTicketsForPassenger(RepoGetAllTicketsForPassengerRequest request)
        {
            RepoBaseResponse<ICollection<Rezervacii>> response = new RepoBaseResponse<ICollection<Rezervacii>>();
            try
            {
                response.ReturnedResult = Context.Rezervacii.Where(x => x.PatnikId == request.PassengerId)
                    .OrderByDescending(x => x.DatumNaIzdavanje).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Sedishta>> GetAvailabelSeatsForFlightSCheme(RepoGetAvailabelSeatsForFlightSChemeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
