using System;
using Db201617zVaProektRnabContext;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Interfaces
{
    interface IAccountManager
    {
        RepoBaseResponse<Akaunti> RegisterAccount(RepoRegisterAccountRequest request);
        RepoBaseResponse<Akaunti> GetAccountById(RepoGetAccountByIdRequest request);
        RepoBaseResponse<Akaunti> GetAccountByUserName(RepoGetAccountByUserNameRequest request);
        RepoBaseResponse<Akaunti> GetAccountByEmailAddress(RepoGetAccountByEmailAddressRequest request);
        RepoBaseResponse<Akaunti> UpdateEmailAddress(RepoUpdateEmailAddressRequest request);
        RepoBaseResponse<Akaunti> ChangePassword(RepoChangePasswordRequest request);
        RepoBaseResponse<Akaunti> RemoveUnlinkedAccount(RepoRemoveUnlinkedAccountRequest request);
    }
}
