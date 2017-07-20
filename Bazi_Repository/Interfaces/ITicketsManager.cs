using System;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Interfaces
{
    interface ITicketsManager
    {
        RepoBaseResponse<Rezervacii> AddNewTicket(RepoAddNewTicketRequest request);
        RepoBaseResponse<Rezervacii> ExtendTicket(RepoExtendTicketRequest request);
        RepoBaseResponse<ICollection<Rezervacii>> GetAllTicketsForPassenger(RepoGetAllTicketsForPassengerRequest request);
        RepoBaseResponse<ICollection<Rezervacii>> GetAllTicketsForFlightScheme(RepoGetAllTicketsForFlightSchemeRequest request);
        RepoBaseResponse<ICollection<Sedishta>> GetAvailabelSeatsForFlightSCheme(RepoGetAvailabelSeatsForFlightSChemeRequest request);
        RepoBaseResponse<Rezervacii> CancelTicket(RepoCancelTicketRequest request);
    }
}
