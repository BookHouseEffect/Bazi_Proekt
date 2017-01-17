using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Business.Interfaces;
using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Repository.Implementation;
using Bazi_Repository;
using Db201617zVaProektRnabContext;
using System.Net;

namespace Bazi_Business.Implementation
{
    public class AccountService : IAccountService
    {
        AccountManager AccountManager;
        PasswordCryptography PasswordCryptography;

        public AccountService()
        {
            AccountManager = new AccountManager();
            PasswordCryptography = new PasswordCryptography();
        }

        public LogInResponse LogIn(LogInRequest request)
        {
            LogInResponse response = new LogInResponse();
            
            try
            {
                RepoBaseResponse<Akaunti> repores = AccountManager.GetAccountByUserName(
                    new Bazi_Repository.RepositoryRequests.RepoGetAccountByUserNameRequest { Username = request.Username });
                if (repores.Status == HttpStatusCode.OK)
                    response.Account = repores.ReturnedResult;
                else
                    throw response.Exception;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = "A problem occured in our servers. We are working on it. Please, try again later.";
                response.Account = null;
            }

            
            if (response.Account != null)
            {
                if (!PasswordCryptography.PasswordCompare(
                    new HashedAndSaltedPassword
                    {
                        PasswordHash = response.Account.LozinkaHash,
                        PasswordSalt = response.Account.BezbednostnaMarka
                    }, request.Password))
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.Message = "Your password is incorrect. Please, try again!";
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "This username was not found in out database. Please, check your username.";
            }

            return response;
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
