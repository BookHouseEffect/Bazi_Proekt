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
    class PriceManager : BaseManager, IPriceManager
    {
        public RepoBaseResponse<Cenovnici> AddNewFlightPrice(RepoAddNewFlightPriceRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Cenovnici> GetPriceListByFlightSCheme(RepoGetPriceListByFlightSChemeRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Cenovnici> GetPriceListById(RepoGetPriceListByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Cenovnici> UpdatePriceInfo(RepoUpdatePriceInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
