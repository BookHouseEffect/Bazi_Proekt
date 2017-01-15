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
    class CompanyManager : BaseManager, ICompanyManager
    {
        public RepoBaseResponse<Aviokompanii> GetCompanyById(RepoGetCompanyByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aviokompanii> GetCompanyByName(RepoGetCompanyByNameRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Aviokompanii>> GetCompanyList()
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> RegisterCompany(RepoRegisterCompanyRequest requset)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aviokompanii> UpdateCompanyAddressInfo(RepoUpdateCompanyAddressInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aviokompanii> UpdateCompanyInfo(RepoUpdateCompanyInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
