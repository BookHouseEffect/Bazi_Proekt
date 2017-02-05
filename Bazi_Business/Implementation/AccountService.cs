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
using Bazi_Repository.RepositoryRequests;

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
                response.SetInternalServerErrorMessage(ex);
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

        public RegisterCompanyResponse RegisterCompany(RegisterCompanyRequest request)
        {
            RegisterCompanyResponse response = new RegisterCompanyResponse();
            try
            {
                HashedAndSaltedPassword hashAndSalt =  PasswordCryptography.CryptPassword(request.Password);

                CompanyManager companyManager = new CompanyManager();
                RepoBaseResponse<Aviokompanii> repoResponse =
                    companyManager.RegisterCompany(new RepoRegisterCompanyRequest
                    {
                        Account = request.CompanyAccount,
                        Address = request.CompanyAddress,
                        CompanyName = request.Company.ImeNaKompanija,
                        PasswordHash = hashAndSalt.PasswordHash,
                        SecurityStamp = hashAndSalt.PasswordSalt
                    });

                if (repoResponse.Status == HttpStatusCode.OK)
                    response.RegisteredCompany = repoResponse.ReturnedResult;
                else
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Exception = repoResponse.Exception;
                }

                response.Message = repoResponse.Message;

            } catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }

            return response;
        }

        public RegisterPassengerResponse RegisterPassenger(RegisterPassengerRequest request)
        {
            RegisterPassengerResponse response = new RegisterPassengerResponse();
            try
            {
                HashedAndSaltedPassword hashAndSalt = PasswordCryptography.CryptPassword(request.Password);

                PassengerManager passengerManager = new PassengerManager();
                RepoBaseResponse<Patnici> repoResponse =
                    passengerManager.AddPassengerAccount(new RepoAddPassengerAccountRequest
                    {
                        Account = request.PassengerAccount,
                        Address = request.PassengerAddress,
                        Person = request.Person, 
                        Passenger = request.Passenger,
                        PasswordHash = hashAndSalt.PasswordHash,
                        SecurityStamp = hashAndSalt.PasswordSalt
                    });

                if (repoResponse.Status == HttpStatusCode.OK)
                    response.RegisterdPassenger = repoResponse.ReturnedResult;
                else
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Exception = repoResponse.Exception;
                }

                response.Message = repoResponse.Message;

            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }

            return response;
        }

        public RegisterEmployeeResponse RegisterEmployee(RegisterEmployeeRequest request)
        {
            RegisterEmployeeResponse response = new RegisterEmployeeResponse();
            try
            {
                HashedAndSaltedPassword hashAndSalt = PasswordCryptography.CryptPassword(request.Password);

                EmployeeManager employeeManager = new EmployeeManager();
                RepoBaseResponse<Vraboteni> repoResponse =
                    employeeManager.AddEmployeeAccount(new RepoAddEmployeeAccountRequest
                    {
                        Account = request.EmployeeAccount,
                        Person = request.Person,
                        Employee = request.Employee, 
                        CompanyAccountId = request.CompanyAccountId,
                        PasswordHash = hashAndSalt.PasswordHash,
                        SecurityStamp = hashAndSalt.PasswordSalt
                    });

                if (repoResponse.Status == HttpStatusCode.OK)
                    response.RegisteredEmployee = repoResponse.ReturnedResult;
                else
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Exception = repoResponse.Exception;
                }

                response.Message = repoResponse.Message;

            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }

            return response;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = new ChangePasswordResponse();
            try
            {
                RepoBaseResponse<Akaunti> currentAccount = AccountManager.GetAccountById(new RepoGetAccountByIdRequest { Id = request.AccoundId });
                if (currentAccount.Status != HttpStatusCode.OK || currentAccount.ReturnedResult == null)
                    throw currentAccount.Exception;

                if (PasswordCryptography.PasswordCompare(
                    new HashedAndSaltedPassword
                    {
                        PasswordHash = currentAccount.ReturnedResult.LozinkaHash,
                        PasswordSalt = currentAccount.ReturnedResult.BezbednostnaMarka
                    }
                    , request.OldPassword))
                {
                    HashedAndSaltedPassword newPassHash = PasswordCryptography.CryptPassword(request.NewPassword);
                    RepoBaseResponse<Akaunti> newAccount = AccountManager.ChangePassword(new RepoChangePasswordRequest
                    {
                        Id = request.AccoundId,
                        PasswordHash = newPassHash.PasswordHash,
                        SecurityStamp = newPassHash.PasswordSalt
                    });

                    if (newAccount.Status != HttpStatusCode.OK || newAccount.ReturnedResult == null)
                        throw newAccount.Exception;
                    response.Account = newAccount.ReturnedResult;
                    response.Message = "Password changed successfully";
                }
                else
                    throw new Exception("The password is incorrect.");
            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }

        public GetCompanyInfoResponse GetComapnyInfo(GetCompanyInfoRequest request)
        {
            GetCompanyInfoResponse response = new GetCompanyInfoResponse();
            try
            {
                CompanyManager companyManager = new CompanyManager();
                RepoBaseResponse<Aviokompanii> comResponse =  companyManager
                    .GetCompanyByAccountId(new RepoGetCompanyByAccountIdRequest { AccountId = request.AccountId });
                if (comResponse.Status != HttpStatusCode.OK || comResponse.ReturnedResult == null)
                {
                    RepoBaseResponse<Akaunti> acResponse = AccountManager.GetAccountById(new RepoGetAccountByIdRequest { Id = request.AccountId });
                    if (acResponse.Status != HttpStatusCode.OK || acResponse.ReturnedResult == null)
                        throw acResponse.Exception;
                    else
                        response.Account = acResponse.ReturnedResult;
                } else
                {
                    response.Company = comResponse.ReturnedResult;
                    response.Account = comResponse.ReturnedResult.Akaunti_AkauntId;
                }

            } catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }

        public GetPassengerInfoResponse GetPassengerInfo(GetPassengerInfoRequest request)
        {
            GetPassengerInfoResponse response = new GetPassengerInfoResponse();
            try
            {
                RepoBaseResponse<Akaunti> acResponse = AccountManager.GetAccountById(new RepoGetAccountByIdRequest { Id = request.AccountId });
                if (acResponse.Status != HttpStatusCode.OK || acResponse.ReturnedResult == null)
                    throw acResponse.Exception;
                else
                    response.Account = acResponse.ReturnedResult;

                PassengerManager passengerManager = new PassengerManager();
                RepoBaseResponse<ICollection<Patnici>> passResponse = passengerManager
                    .GetPassengersByAccount(new RepoGetPassengersByAccountRequest { AccountId = request.AccountId });
                if (passResponse.Status != HttpStatusCode.OK || passResponse.ReturnedResult == null)
                    response.Passengers = new List<Patnici>();
                else
                    response.Passengers = passResponse.ReturnedResult;
            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }

        public UpdateCompanyResponse UpdateCompany(UpdateCompanyRequest request)
        {
            UpdateCompanyResponse response = new UpdateCompanyResponse();
            try
            {
                CompanyManager companyManager = new CompanyManager();
                RepoBaseResponse<Aviokompanii> responseInfo =  companyManager.UpdateCompanyInfo(new RepoUpdateCompanyInfoRequest
                {
                    AccountId = request.AkauntId,
                    CompanyId = request.CompanyId,
                    NewCompanyName = request.Company.ImeNaKompanija
                });
                if (responseInfo.Status != HttpStatusCode.OK || responseInfo.ReturnedResult == null)
                    throw responseInfo.Exception;

                RepoBaseResponse<Aviokompanii> responseAddress = companyManager.UpdateCompanyAddressInfo(new RepoUpdateCompanyAddressInfoRequest
                {
                    AccountId = request.AkauntId,
                    CompanyId = request.CompanyId,
                    NewAddress = request.Address
                });
                if (responseAddress.Status != HttpStatusCode.OK || responseAddress.ReturnedResult == null)
                    throw responseAddress.Exception;

                response.Company = responseAddress.ReturnedResult;
                response.Message = "Company info Successfully Updated.";
            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }

        public UpdatePassengerResponse UpdatePassenger(UpdatePassengerRequest request)
        {
            UpdatePassengerResponse response = new UpdatePassengerResponse();
            try
            {
                PassengerManager passengerManager = new PassengerManager();
                RepoBaseResponse<Patnici> responsePerson = passengerManager.UpdatePassengerPersonInfo(new RepoUpdatePassengerPersonInfoRequest
                {
                    AccountId = request.AkauntId,
                    PassengerId = request.PassengerId,
                    NewPerson = request.Person
                });
                if (responsePerson.Status != HttpStatusCode.OK || responsePerson.ReturnedResult == null)
                    throw responsePerson.Exception;

                RepoBaseResponse<Patnici> responseAddress = passengerManager.UpdatePassengerAddressInfo(new RepoUpdatePassengerAddressInfoRequest
                {
                    AccountId = request.AkauntId,
                    PassengerId = request.PassengerId, 
                    NewAddress = request.Address
                });
                if (responseAddress.Status != HttpStatusCode.OK || responseAddress.ReturnedResult == null)
                    throw responseAddress.Exception;

                RepoBaseResponse<Patnici> resposeInfo = passengerManager.UpdatePassengerInfo(new RepoUpdatePassengerInfoRequest
                {
                    AccountId = request.AkauntId,
                    PassengerId = request.PassengerId,
                    NewPassenger = request.Passenger
                });
                if (resposeInfo.Status != HttpStatusCode.OK || resposeInfo.ReturnedResult == null)
                    throw resposeInfo.Exception;

                response.Passenger = resposeInfo.ReturnedResult;
                response.Message = "Personal info Successfully Updated.";
            }
            catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }
    }
}
