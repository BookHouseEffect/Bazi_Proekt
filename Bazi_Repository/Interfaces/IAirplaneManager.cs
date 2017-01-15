using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IAirplaneManager
    {
        RepoBaseResponse<Avioni> AddCompanyAirplane(RepoAddCompanyAirplaneRequest request);
        RepoBaseResponse<Avioni> GetCompanyAirplaneById(RepoGetCompanyAirplaneByIdRequest request);
        RepoBaseResponse<Avioni> GetCompanyAirplaneByRegistry(RepoGetCompanyAirplaneByRegistryRequest request);
        RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanesByType(RepoGetCompanyAirplanesByTypeRequest request);
        RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanes(RepoGetCompanyAirplanesRequest request);
        RepoBaseResponse<Avioni> UpdateCompanyAirplaneName(RepoUpdateCompanyAirplaneNameRequest request);
        RepoBaseResponse<Avioni> UpdateCompanyAirplaneRegistry(RepoUpdateCompanyAirplaneRegistryRequest request);
        RepoBaseResponse<Boolean> TransferAirplaneToNewCompany(RepoTransferAirplaneToNewCompanyRequest request);
    }
}
