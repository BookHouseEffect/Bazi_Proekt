using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Interfaces
{
    interface IPriceManager
    {
        RepoBaseResponse<Cenovnici> AddNewFlightPrice(RepoAddNewFlightPriceRequest request);
        RepoBaseResponse<Cenovnici> UpdatePriceInfo(RepoUpdatePriceInfoRequest request);
        RepoBaseResponse<Cenovnici> GetPriceListById(RepoGetPriceListByIdRequest request);
        RepoBaseResponse<Cenovnici> GetPriceListByFlightSCheme(RepoGetPriceListByFlightSChemeRequest request);
    }
}
