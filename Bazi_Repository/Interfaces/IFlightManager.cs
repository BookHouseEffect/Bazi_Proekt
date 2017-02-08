using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.Interfaces
{
    interface IFlightManager
    {
        RepoBaseResponse<Letovi> AddNewFlight(RepoAddNewFlightRequest request);
        RepoBaseResponse<Letovi> GetFlightById(RepoGetFlightByIdRequest request);
        RepoBaseResponse<Letovi> RemoveFlightIfNotAssigned(RepoRemoveFlightIfNotAssignedRequest request);
    }
}
