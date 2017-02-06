using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewFlightRequest : RepoBaseRequest
    {
        public int CompanyId { get; set; }
        public ICollection<Megjuletovi> SubFlightList { get; set; }
        public ICollection<Int32> FlightDayList { get; set; }
        public ICollection<TimeSpan> DeparturesTime { get; set; }
    }

    public class RepoGetFlightByIdRequest : RepoBaseRequest
    {
        public Int32 flightId { get; set; }
    }

    public class RepoRemoveFlightIfNotAssignedRequest : RepoBaseRequest
    {
        public Int32 flightId { get; set; }
    }
}
