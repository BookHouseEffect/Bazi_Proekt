using Bazi_Repository.Interfaces;
using System;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    sealed public class AccountManager : BaseManager, IAccountManager
    {
        public AccountManager() { }

        private Akaunti GetById(int id)
        {
            return Context.Akaunti.Where(x => x.AkauntId == id).Single();
        }

        public RepoBaseResponse<Akaunti> ChangePassword(RepoChangePasswordRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                Akaunti currentAccount = GetById(request.Id);
                currentAccount.LozinkaHash = request.PasswordHash;
                currentAccount.BezbednostnaMarka = request.SecurityStamp;
                Context.SubmitChanges();
                response.ReturnedResult = currentAccount;
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Akaunti> GetAccountByEmailAddress(RepoGetAccountByEmailAddressRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                response.ReturnedResult = Context.Akaunti.Where(x => x.EmailAdresa == request.Email).Single();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Akaunti> GetAccountByUserName(RepoGetAccountByUserNameRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                response.ReturnedResult = Context.Akaunti.Where(x => x.KorisnichkoIme == request.Username).Single();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Akaunti> RegisterAccount(RepoRegisterAccountRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            RoleManager roleManager = new RoleManager();
            try
            {
                RepoBaseResponse<Ulogi> currentRoleResponse = roleManager.GetRoleById(new RepoGetRoleByIdRequest { RoleId = request.Role.UlogaId });
                if (currentRoleResponse.Status != System.Net.HttpStatusCode.OK)
                    throw currentRoleResponse.Exception;
                if (!Object.Equals(request.Role, currentRoleResponse.ReturnedResult))
                    throw new Exception("Inconsistent Role Received.");
                request.Account.UlogaId = currentRoleResponse.ReturnedResult.UlogaId;
                Context.Akaunti.InsertOnSubmit(request.Account);
                Context.SubmitChanges();
                response.ReturnedResult = request.Account;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Akaunti> UpdateEmailAddress(RepoUpdateEmailAddressRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                Akaunti account = GetById(request.Id);
                if (account.EmailAdresa == request.NewEmail)
                    throw new Exception("This email address is alredy up to date.");
                int count = Context.Akaunti.Count(x => x.EmailAdresa == request.NewEmail);
                if (count > 0)
                    throw new Exception("This email address is alredy in use.");
                account.EmailAdresa = request.NewEmail;
                Context.SubmitChanges();
                response.ReturnedResult = account;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Akaunti> GetAccountById(RepoGetAccountByIdRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                response.ReturnedResult = GetById(request.Id);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
