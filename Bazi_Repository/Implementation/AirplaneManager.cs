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
    class AirplaneManager : BaseManager, IAirplaneManager
    {
        public RepoBaseResponse<Avioni> AddCompanyAirplane(RepoAddCompanyAirplaneRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Avioni> GetCompanyAirplaneById(RepoGetCompanyAirplaneByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Avioni> GetCompanyAirplaneByRegistry(RepoGetCompanyAirplaneByRegistryRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanes(RepoGetCompanyAirplanesRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanesByType(RepoGetCompanyAirplanesByTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> TransferAirplaneToNewCompany(RepoTransferAirplaneToNewCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Avioni> UpdateCompanyAirplaneName(RepoUpdateCompanyAirplaneNameRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Avioni> UpdateCompanyAirplaneRegistry(RepoUpdateCompanyAirplaneRegistryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
