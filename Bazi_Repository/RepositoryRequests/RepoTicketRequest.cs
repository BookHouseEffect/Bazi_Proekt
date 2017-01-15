using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewTicketRequest : RepoBaseRequest
    {
        public Patnici Passenger { get; set; }
        public Sedishta Seat { get; set; }
        public PlanoviNaLetanje FlightScheme { get; set; }
        public Rezervacii Ticket { get; set; }
    }

    public class RepoExtendTicketRequest : RepoBaseRequest
    {
        public Int32 TicketId { get; set; }
        public DateTime NewDateTime { get; set; }
    }

    public class RepoGetAllTicketsForPassengerRequest : RepoBaseRequest
    {
        public Int32 PassengerId { get; set; }
    }

    public class RepoGetAllTicketsForFlightSchemeRequest : RepoBaseRequest
    {
        public Int32 FlightSchemeId { get; set; }
    }

    public class RepoGetAvailabelSeatsForFlightSChemeRequest : RepoBaseRequest
    {
        public Int32 FlightSChemeId { get; set; }
    }

    public class RepoCancelTicketRequest : RepoBaseRequest
    {
        public Int32 TicketId { get; set; }
        public Int32 PassengerId { get; set; }
        public Int32 FlightSchemeId { get; set; }
    }
}
