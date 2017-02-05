using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.Interfaces
{
    interface ISubFlightManager
    {
        RepoBaseResponse<Megjuletovi> AddNewSubFlight(RepoAddNewSubFlightRequest request);
        RepoBaseResponse<Megjuletovi> GetSubFlightById(RepoGetSubFlightByIdRequest request);
        RepoBaseResponse<Megjuletovi> UpdateSubFlightTimeAndDistance(RepoUpdateSubFlightTimeAndDistanceRequest request);
        RepoBaseResponse<Boolean> RemoveSubFlightIfUnassigned(RepoRemoveSubFlightIfUnassignedRequest request);
    }
}
