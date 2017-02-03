﻿using System;
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
    }
}
