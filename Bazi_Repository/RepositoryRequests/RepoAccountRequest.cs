using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoRegisterAccountRequest : RepoBaseRequest
    {
        public Akaunti Account { get; set; }
        public Ulogi Role { get; set; }
    }

    public class RepoGetAccountByUserNameRequest : RepoBaseRequest
    {
        public String Username { get; set; }
    }

    public class RepoGetAccountByEmailAddressRequest : RepoBaseRequest
    {
        public String Email { get; set; }
    }

    public class RepoUpdateEmailAddressRequest : RepoBaseRequest
    {
        public Int32 Id { get; set; }
        public String NewEmail { get; set; }
    }

    public class RepoChangePasswordRequest : RepoBaseRequest
    {
        public Int32 Id { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp { get; set; }
    }

    public class RepoGetAccountByIdRequest
    {
        public Int32 Id { get; set; }
    }
}
