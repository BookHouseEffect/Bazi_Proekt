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
    class FlightManager : BaseManager, IFlightManager
    {
        public RepoBaseResponse<Letovi> AddNewFlight(RepoAddNewFlightRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Letovi> GetFlightById(RepoGetFlightByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> RemoveFlightIfNotAssigned(RepoRemoveFlightIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
