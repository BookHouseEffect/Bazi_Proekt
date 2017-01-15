using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class EmployeeManager : BaseManager, IEmployeeManager
    {
        public RepoBaseResponse<Vraboteni> AddEmployeeAccount(RepoAddEmployeeAccountRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Vraboteni> GetEmployeeAccountById(RepoGetEmployeeAccountByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Vraboteni>> GetEmployeesByCompany(RepoGetEmployeesByCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Vraboteni> UpdateEmployeeInfo(RepoUpdateEmployeeInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Vraboteni> UpdateEmployeePersonInfo(RepoUpdateEmployeePersonInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
