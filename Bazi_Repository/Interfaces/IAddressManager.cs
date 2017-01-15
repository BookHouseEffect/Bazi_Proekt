using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IAddressManager
    {
        RepoBaseResponse<Adresi> AddNewAddress(RepoAddNewAddressRequest request);
        RepoBaseResponse<ICollection<String>> GetAllStates();
        RepoBaseResponse<ICollection<String>> GetAllRegions(RepoGetAllRegionsRequest request);
        RepoBaseResponse<ICollection<String>> GetAllCities(RepoGetAllCitiesRequest request);
        RepoBaseResponse<ICollection<String>> GetAllStreets(RepoGetAllStreetsRequest request);
        RepoBaseResponse<Adresi> CheckIfAddressExist(RepoCheckIfAddressExistRequest request);
        RepoBaseResponse<Adresi> UpdateAddressInfo(RepoUpdateAddressInfoRequest request);
    }
}
