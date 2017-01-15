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
    class TicketsManager : BaseManager, ITicketsManager
    {
        public RepoBaseResponse<Rezervacii> AddNewTicket(RepoAddNewTicketRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> CancelTicket(RepoCancelTicketRequest request)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Sedishta>> GetAvailabelSeatsForFlightSCheme(RepoGetAvailabelSeatsForFlightSChemeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
