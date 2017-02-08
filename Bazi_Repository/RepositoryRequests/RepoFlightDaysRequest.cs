using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAssignFlightDaysRequest : RepoBaseRequest
    {
        public int FlightId { get; set; }
        public ICollection<Int32> FlightDayList { get; set; }
    }
}
