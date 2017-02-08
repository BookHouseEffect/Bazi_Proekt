using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewFlightSchemeRequest : RepoBaseRequest
    {
        public Int32 AirplaneId { get; set; }
        public ICollection<Megjuletovi> SubFlight { get; set; }
        public String Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }

    public class RepoGetFlightSchemeByIdRequest : RepoBaseRequest
    {
        public Int32 FlightSchemeId { get; set; }
    }

    public class RepoGetFlightSchemesBySubFlightRequest : RepoBaseRequest
    {
        public Int32 SubflightId { get; set; }
    }

    public class RepoUpdateFlightSchemeInfoRequest : RepoBaseRequest
    {
        public Int32 FlightSchemeId { get; set; }
        public PlanoviNaLetanje NewFlightScheme { get; set; }
    }
}
