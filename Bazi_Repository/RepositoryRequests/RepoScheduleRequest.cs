using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewScheduleRequest : RepoBaseRequest
    {
        public ICollection<Megjuletovi> SubFlights { get; set; }
        public ICollection<TimeSpan> DeparturesTime { get; set; }
        public ICollection<Int32> FlightDayList { get; set; }
        public TimeSpan RequiredWaitingInterval { get; set; }
    }

    public class RepoGetScheduleByIdRequest : RepoBaseRequest
    {
        public Int32 ScheduleId { get; set; }
    }

    public class RepoGetScheduleBySubFlightRequest : RepoBaseRequest
    {
        public Int32 SubFlightId { get; set; }
    }

    public class RepoGetScheduleByFlightRequest : RepoBaseRequest
    {
        public Int32 FlightId { get; set; }
    }

    public class RepoUpdateScheduleInfoRequest : RepoBaseRequest
    {
        public Int32 ScheduleId { get; set; }
        public Int32 SubFlightId { get; set; }
        public Rasporedi NewRaspored { get; set; }
    }
}
