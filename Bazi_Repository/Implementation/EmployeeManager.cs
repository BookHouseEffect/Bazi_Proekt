using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Net;

namespace Bazi_Repository.Implementation
{
    public class EmployeeManager : BaseManager, IEmployeeManager
    {

        public EmployeeManager(): base() { }
        public EmployeeManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Vraboteni GetById(int employeId, int accountId)
        {
            return Context.Vraboteni.Where(x => x.VrabotenId == employeId && x.AkauntId == accountId).SingleOrDefault();
        }

        private Vraboteni GetById(int companyId, int employeId, int accountId)
        {
            return Context.Vraboteni.Where(x => x.VrabotenId == employeId && x.AkauntId == accountId && x.KompanijaId == companyId).SingleOrDefault();
        }

        public RepoBaseResponse<Vraboteni> AddEmployeeAccount(RepoAddEmployeeAccountRequest request)
        {
            RepoBaseResponse<Vraboteni> response = new RepoBaseResponse<Vraboteni>();

            PersonManager personManager = new PersonManager(this.Context);
            RepoBaseResponse<Lugje> personResponse = null;

            AccountManager accountManager = new AccountManager(this.Context);
            RepoBaseResponse<Akaunti> accountResponse = null;

            try
            {
                RoleManager roleManager = new RoleManager(this.Context);
                RepoBaseResponse<Ulogi> employeeRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Employee" });
                if (employeeRole.HasError())
                    throw employeeRole.Exception;


                CompanyManager companyManager = new CompanyManager(this.Context);
                RepoBaseResponse<Aviokompanii> companyResponse = companyManager.GetCompanyByAccountId(new RepoGetCompanyByAccountIdRequest { AccountId = request.CompanyAccountId });
                if (companyResponse.HasError())
                    throw companyResponse.Exception;


                personResponse = personManager.AddNewPerson(new RepoAddNewPersonRequest() { Person = request.Person });
                if (personResponse.HasError())
                    throw personResponse.Exception;

                accountResponse = accountManager.RegisterAccount(new RepoRegisterAccountRequest {
                        Account = request.Account,
                        Role = employeeRole.ReturnedResult,
                        PasswordHash = request.PasswordHash,
                        SecurityStamp = request.SecurityStamp
                    });
                if (accountResponse.HasError())
                    throw accountResponse.Exception;

                Vraboteni employee = new Vraboteni
                {
                    AkauntId = accountResponse.ReturnedResult.AkauntId,
                    CovekId = personResponse.ReturnedResult.CovekId,
                    KompanijaId = companyResponse.ReturnedResult.KompanijaId
                };
                Context.Vraboteni.InsertOnSubmit(employee);
                Context.SubmitChanges();
                response.ReturnedResult = employee;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);

                if (personResponse != null)
                {
                    RepoBaseResponse<Lugje> removedPerson = personManager.RemoveUnlinkedPerson(new RepoRemoveUnlinkedPersonRequest { PersonId = personResponse.ReturnedResult.CovekId });
                    if (removedPerson.HasError()) response.Message += removedPerson.Message;
                }

                if (accountResponse != null)
                {
                    RepoBaseResponse<Akaunti> removeAccount = accountManager.RemoveUnlinkedAccount(new RepoRemoveUnlinkedAccountRequest { Id = accountResponse.ReturnedResult.AkauntId });
                    if (removeAccount.HasError()) response.Message += removeAccount.Message;
                }
            }

            return response;
        }

        public RepoBaseResponse<Vraboteni> GetEmployeeAccountById(RepoGetEmployeeAccountByIdRequest request)
        {
            RepoBaseResponse<Vraboteni> response = new RepoBaseResponse<Vraboteni>();
            try
            {
                response.ReturnedResult = GetById(request.EmployeeId, request.AccountId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Vraboteni>> GetEmployeesByCompany(RepoGetEmployeesByCompanyRequest request)
        {
            RepoBaseResponse<ICollection<Vraboteni>> response = new RepoBaseResponse<ICollection<Vraboteni>>();
            try
            {
                response.ReturnedResult = Context.Vraboteni.Where(x => x.KompanijaId == request.CompanyId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Vraboteni> UpdateEmployeePersonInfo(RepoUpdateEmployeePersonInfoRequest request)
        {
            RepoBaseResponse<Vraboteni> response = new RepoBaseResponse<Vraboteni>();

            try
            {
                Vraboteni currentEmployee = GetById(request.CompanyId, request.EmployeeId, request.AccountId);
                if (currentEmployee == null)
                    throw new Exception("The employee does not exist.");

                PersonManager personManager = new PersonManager(this.Context);
                RepoBaseResponse<Lugje> updatePerson = personManager.UpdatePersonInfo(new RepoUpdatePersonInfoRequest
                {
                    PersonId = currentEmployee.CovekId,
                    NewPerson = request.NewPerson
                });

                if (updatePerson.HasError())
                    throw updatePerson.Exception;

                currentEmployee.CovekId = updatePerson.ReturnedResult.CovekId;
                Context.SubmitChanges();
                response.ReturnedResult = currentEmployee;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Vraboteni> UpdateEmployeeInfo(RepoUpdateEmployeeInfoRequest request)
        {
            RepoBaseResponse<Vraboteni> response = new RepoBaseResponse<Vraboteni>();
            try
            {
                Vraboteni currentEmployee = GetById(request.CompanyId, request.EmployeeId, request.AccountId);
                if (currentEmployee == null)
                    throw new Exception("The employee does not exist.");

                //Nothing to update. Returning only the result
                
                response.ReturnedResult = currentEmployee;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
