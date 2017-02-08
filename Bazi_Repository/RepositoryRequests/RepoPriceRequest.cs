using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.RepositoryRequests
{

    public class RepoAddNewFlightPriceRequest : RepoBaseRequest
    {
        public Int32 FlightSchemeId { get; set; }
        public ICollection<Klasi> AirplaneClass { get; set; }
        public ICollection<ICollection<Cenovnici>> PriceList { get; set; }
    }

    public class RepoUpdatePriceInfoRequest : RepoBaseRequest
    {
        public Int32 FlightPriceId { get; set; }
        public Int32 FlightSchemeId { get; set; }
        public Int32 ClassId { get; set; }
        public Cenovnici NewPriceList { get; set; }
    }

    public class RepoGetPriceListByIdRequest : RepoBaseRequest
    {
        public Int32 PriceListId { get; set; }
    }

    public class RepoGetPriceListByFlightSChemeRequest : RepoBaseRequest
    {
        public Int32 FlightSchemeId { get; set; }
    }
}
