using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface ISubFlightManager
    {
        RepoBaseResponse<ICollection<Megjuletovi>> AddNewSubFlights(RepoAddNewSubFlightsRequest request);
        RepoBaseResponse<Megjuletovi> GetSubFlightById(RepoGetSubFlightByIdRequest request);
        RepoBaseResponse<ICollection<Megjuletovi>> GetSubFlightByFlightId(RepoGetSubFlightByFlightIdRequest request);
        RepoBaseResponse<Megjuletovi> RemoveSubFlightIfUnassigned(RepoRemoveSubFlightIfUnassignedRequest request);
    }
}
