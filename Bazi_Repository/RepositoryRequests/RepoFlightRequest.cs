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
        public ICollection<Megjuletovi> SubFlightList { get; set; }
        public ICollection<DenoviNaLetanje> FlightDayList { get; set; }
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
