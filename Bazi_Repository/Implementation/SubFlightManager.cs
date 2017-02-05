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
    class SubFlightManager : BaseManager, ISubFlightManager
    {
        public RepoBaseResponse<Megjuletovi> AddNewSubFlight(RepoAddNewSubFlightRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Megjuletovi> GetSubFlightById(RepoGetSubFlightByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> RemoveSubFlightIfUnassigned(RepoRemoveSubFlightIfUnassignedRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Megjuletovi> UpdateSubFlightTimeAndDistance(RepoUpdateSubFlightTimeAndDistanceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
