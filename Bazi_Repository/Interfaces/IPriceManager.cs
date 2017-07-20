using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IPriceManager
    {
        RepoBaseResponse<ICollection<Cenovnici>> AddNewFlightPrice(RepoAddNewFlightPriceRequest request);
        RepoBaseResponse<Cenovnici> UpdatePriceInfo(RepoUpdatePriceInfoRequest request);
        RepoBaseResponse<Cenovnici> GetPriceListById(RepoGetPriceListByIdRequest request);
        RepoBaseResponse<ICollection<Cenovnici>> GetPriceListByFlightSCheme(RepoGetPriceListByFlightSChemeRequest request);
    }
}
