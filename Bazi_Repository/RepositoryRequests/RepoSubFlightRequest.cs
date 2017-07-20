using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewSubFlightsRequest : RepoBaseRequest
    {
        public ICollection<Megjuletovi> SubFlights { get; set; }
        public Int32 FlightId { get; set; }
    }

    public class RepoGetSubFlightByIdRequest : RepoBaseRequest
    {
        public Int32 SubFlightId { get; set; }
    }

    public class RepoRemoveSubFlightIfUnassignedRequest : RepoBaseRequest
    {
        public Int32 SubFlightId { get; set; }
    }

    public class RepoGetSubFlightByFlightIdRequest : RepoBaseRequest
    {
        public Int32 FlightId { get; set; }
    }
}
