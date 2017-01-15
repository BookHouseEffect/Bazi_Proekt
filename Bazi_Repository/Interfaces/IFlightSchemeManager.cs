using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IFlightSchemeManager
    {
        RepoBaseResponse<PlanoviNaLetanje> AddNewFlightScheme(RepoAddNewFlightSchemeRequest request);
        RepoBaseResponse<PlanoviNaLetanje> GetFlightSchemeById(RepoGetFlightSchemeByIdRequest request);
        RepoBaseResponse<ICollection<PlanoviNaLetanje>> GetFlightSchemesBySubFlight(RepoGetFlightSchemesBySubFlightRequest request);
        RepoBaseResponse<PlanoviNaLetanje> UpdateFlightSchemeInfo(RepoUpdateFlightSchemeInfoRequest request);
    }
}
