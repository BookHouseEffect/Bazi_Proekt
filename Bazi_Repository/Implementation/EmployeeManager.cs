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
            RoleManager roleManager = new RoleManager(this.Context);
            RepoBaseResponse<Ulogi> employeeRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Employee" });
            if (employeeRole.Status != HttpStatusCode.OK || employeeRole.ReturnedResult == null)
                throw employeeRole.Exception;

            RepoBaseResponse<Vraboteni> response = new RepoBaseResponse<Vraboteni>();
            bool accountCreated = false, personAdded = false, employeeCreated = false;
            try
            {
                CompanyManager companyManager = new CompanyManager(this.Context);
                RepoBaseResponse<Aviokompanii> companyResponse = companyManager.GetCompanyByAccountId(new RepoGetCompanyByAccountIdRequest { AccountId = request.CompanyAccountId });
                if (companyResponse.Status != HttpStatusCode.OK && companyResponse.ReturnedResult != null)
                    throw companyResponse.Exception;

                AccountManager accountManager = new AccountManager(this.Context);
                RepoBaseResponse<Akaunti> accountResponse =
                    accountManager.RegisterAccount(new RepoRegisterAccountRequest
                    {
                        Account = request.Account,
                        Role = employeeRole.ReturnedResult,
                        PasswordHash = request.PasswordHash,
                        SecurityStamp = request.SecurityStamp
                    });
                if (accountResponse.Status != HttpStatusCode.OK ||
                     accountResponse.ReturnedResult == null)
                    throw accountResponse.Exception;
                accountCreated = true;

                PersonManager personManager = new PersonManager(this.Context);
                RepoBaseResponse<Lugje> personResponse = personManager.AddNewPerson(new RepoAddNewPersonRequest() { Person = request.Person });
                if (personResponse.Status != HttpStatusCode.OK || personResponse.ReturnedResult == null)
                    throw personResponse.Exception;
                personAdded = true;

                Vraboteni employee = new Vraboteni
                {
                    AkauntId = accountResponse.ReturnedResult.AkauntId,
                    CovekId = personResponse.ReturnedResult.CovekId,
                    KompanijaId = companyResponse.ReturnedResult.KompanijaId
                };
                Context.Vraboteni.InsertOnSubmit(employee);
                Context.SubmitChanges();
                employeeCreated = true;
                response.ReturnedResult = employee;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
                if (!accountCreated)
                    response.Message += "\nThe account couldn't be created.";
                else
                    response.Message += "\nThe account is created.";

                if (accountCreated && !personAdded)
                    response.Message += "\nThe person information was not saved. Log in to insert the data again";

                if (accountCreated && !employeeCreated)
                    response.Message += "\nThe employee information was not saved. Log in to insert the data again";
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

                if (updatePerson.Status != System.Net.HttpStatusCode.OK || updatePerson.ReturnedResult == null)
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
