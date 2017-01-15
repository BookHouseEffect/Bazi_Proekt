using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IEmployeeManager
    {
        RepoBaseResponse<Vraboteni> AddEmployeeAccount(RepoAddEmployeeAccountRequest request);
        RepoBaseResponse<Vraboteni> GetEmployeeAccountById(RepoGetEmployeeAccountByIdRequest request);
        RepoBaseResponse<ICollection<Vraboteni>> GetEmployeesByCompany(RepoGetEmployeesByCompanyRequest request);
        RepoBaseResponse<Vraboteni> UpdateEmployeeInfo(RepoUpdateEmployeeInfoRequest request);
        RepoBaseResponse<Vraboteni> UpdateEmployeePersonInfo(RepoUpdateEmployeePersonInfoRequest request);
    }
}
