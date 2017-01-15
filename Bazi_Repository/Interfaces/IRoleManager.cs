using Db201617zVaProektRnabContext;
using Bazi_Repository.RepositoryRequests;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IRoleManager
    {
        RepoBaseResponse<Ulogi> GetRoleById(RepoGetRoleByIdRequest request);
        RepoBaseResponse<Ulogi> GetRoleByName(RepoGetRoleByNameRequest request);
        RepoBaseResponse<ICollection<Ulogi>> GetRoleList();
    }
}
