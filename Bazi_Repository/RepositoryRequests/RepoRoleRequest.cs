using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoGetRoleByIdRequest : RepoBaseRequest
    {
        public Int32 RoleId { get; set; }
    }

    public class RepoGetRoleByNameRequest : RepoBaseRequest
    {
        public String RoleName { get; set; }
    }
}
