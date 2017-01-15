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
    class AddressManager : BaseManager, IAddressManager
    {
        public RepoBaseResponse<Adresi> AddNewAddress(RepoAddNewAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Adresi> CheckIfAddressExist(RepoCheckIfAddressExistRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<string>> GetAllCities(RepoGetAllCitiesRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<string>> GetAllRegions(RepoGetAllRegionsRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<string>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<string>> GetAllStreets(RepoGetAllStreetsRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Adresi> UpdateAddressInfo(RepoUpdateAddressInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
