using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IAirplaneTypeManager
    {
        RepoBaseResponse<TipNaAvioni> AddNewType(RepoAddNewTypeRequest request);
        RepoBaseResponse<TipNaAvioni> GetTypeById(RepoGetTypeByIdRequest request);
        RepoBaseResponse<TipNaAvioni> CheckIfTypeExist(RepoCheckIfTypeExistRequest request);
        RepoBaseResponse<ICollection<TipNaAvioni>> GetAllTypes(RepoGetAllTypesRequest request);
        RepoBaseResponse<TipNaAvioni> UpdateTypeInfoIfNotAssigned(RepoUpdateTypeInfoIfNotAssignedRequest request);
        RepoBaseResponse<TipNaAvioni> RemoveTypeIfNotAssigned(RepoRemoveTypeIfNotAssignedRequest request);
    }
}
