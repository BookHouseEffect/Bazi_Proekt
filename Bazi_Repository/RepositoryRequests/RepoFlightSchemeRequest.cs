using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewFlightSchemeRequest : RepoBaseRequest
    {
        public Avioni Airplane { get; set; }
        public Megjuletovi SubFlight { get; set; }
        public PlanoviNaLetanje FlightScheme { get; set; }
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
