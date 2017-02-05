using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewSubFlightRequest : RepoBaseRequest
    {
        public Megjuletovi SubFlight { get; set; }
    }

    public class RepoGetSubFlightByIdRequest : RepoBaseRequest
    {
        public Int32 SubFlightId { get; set; }
    }

    public class RepoUpdateSubFlightTimeAndDistanceRequest : RepoBaseRequest
    {
        public TimeSpan NewFlightTime { get; set; }
        public Single NewDistance { get; set; }
    }

    public class RepoRemoveSubFlightIfUnassignedRequest : RepoBaseRequest
    {
        public Int32 SubFlightId { get; set; }
    }
}
