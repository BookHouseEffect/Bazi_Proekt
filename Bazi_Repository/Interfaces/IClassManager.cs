using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IClassManager
    {
        RepoBaseResponse<ICollection<Klasi>> AddTypeClass(RepoAddTypeClassRequest request);
        RepoBaseResponse<Klasi> GetTypeClassById(RepoGetTypeClassByIdRequest request);
        RepoBaseResponse<ICollection<Klasi>> GetTypeClasses(RepoGetTypeClassesRequest request);
        RepoBaseResponse<Klasi> UpdateTypeClassName(RepoUpdateTypeClassNameRequest request);
        RepoBaseResponse<Boolean> TransferTypeSeatsIfNotAssigned(RepoTransferTypeSeatsIfNotAssignedRequest request);
    }
}
