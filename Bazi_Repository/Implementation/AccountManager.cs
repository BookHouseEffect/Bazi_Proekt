using Bazi_Repository.Interfaces;
using System;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    sealed public class AccountManager : BaseManager, IAccountManager
    {

        public AccountManager(): base() { }
        public AccountManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Akaunti GetById(int id)
        {
            return Context.Akaunti.Where(x => x.AkauntId == id).SingleOrDefault();
        }

        private Akaunti GetByUserName(string username)
        {
            return Context.Akaunti.Where(x => x.KorisnichkoIme == username).SingleOrDefault();
        }

        private Akaunti GetByEmail(string email)
        {
            return Context.Akaunti.Where(x => x.EmailAdresa == email).SingleOrDefault();
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
                response.ReturnedResult = GetByEmail(request.Email);
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
                response.ReturnedResult = GetByUserName(request.Username);
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
            RoleManager roleManager = new RoleManager(this.Context);
            try
            {
                RepoBaseResponse<Ulogi> currentRoleResponse = roleManager.GetRoleById(new RepoGetRoleByIdRequest { RoleId = request.Role.UlogaId });
                if (!currentRoleResponse.IsStatusOk())
                    throw currentRoleResponse.Exception;
                if (!Object.Equals(request.Role, currentRoleResponse.ReturnedResult))
                    throw new Exception("Inconsistent Role Received.");
                if (GetByEmail(request.Account.EmailAdresa) != null)
                    throw new Exception("The email address already exist. Choose another one.");
                if (GetByUserName(request.Account.KorisnichkoIme) != null)
                    throw new Exception("The usernamealready exist. Choose another one.");

                request.Account.UlogaId = currentRoleResponse.ReturnedResult.UlogaId;
                request.Account.LozinkaHash = request.PasswordHash;
                request.Account.BezbednostnaMarka = request.SecurityStamp;
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

        public RepoBaseResponse<Akaunti> RemoveUnlinkedAccount(RepoRemoveUnlinkedAccountRequest request)
        {
            RepoBaseResponse<Akaunti> response = new RepoBaseResponse<Akaunti>();
            try
            {
                Akaunti account = GetById(request.Id);
                if (account == null)
                    throw new Exception("The account does not exist");

                if (account.Aviokompaniis_AkauntId.Count != 0
                    || account.Vrabotenis_AkauntId.Count != 0
                    || account.Patnicis_AkauntId.Count != 0
                    || account.Aviokompaniis_AkauntId.Count != 0)
                    throw new Exception("The account is not deletable");

                this.Context.Akaunti.DeleteOnSubmit(account);
                Context.SubmitChanges();
                response.ReturnedResult = account;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
