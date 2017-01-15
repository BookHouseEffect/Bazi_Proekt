using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class FlightSchemeManager : BaseManager, IFlightSchemeManager
    {
        public RepoBaseResponse<PlanoviNaLetanje> AddNewFlightScheme(RepoAddNewFlightSchemeRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<PlanoviNaLetanje> GetFlightSchemeById(RepoGetFlightSchemeByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<PlanoviNaLetanje>> GetFlightSchemesBySubFlight(RepoGetFlightSchemesBySubFlightRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<PlanoviNaLetanje> UpdateFlightSchemeInfo(RepoUpdateFlightSchemeInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
