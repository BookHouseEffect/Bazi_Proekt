using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewSeatRequest : RepoBaseRequest
    {
        public Int32 ClassId { get; set; }
        public Int32 SeatNumber { get; set; }
    }

    public class RepoRemoveSeatIfNotAssignedRequest : RepoBaseRequest
    {
        public Int32 SeatId { get; set; }
        public Int32 ClassId { get; set; }
    }

    public class RepoGetSeatNumbnersRequest : RepoBaseRequest
    {
        public Int32 ClassId { get; set; }
    }
}
