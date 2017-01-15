using System;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Interfaces
{
    interface ICompanyManager
    {
        RepoBaseResponse<Boolean> RegisterCompany(RepoRegisterCompanyRequest requset);
        RepoBaseResponse<Aviokompanii> GetCompanyById(RepoGetCompanyByIdRequest request);
        RepoBaseResponse<Aviokompanii> GetCompanyByName(RepoGetCompanyByNameRequest request);
        RepoBaseResponse<ICollection<Aviokompanii>> GetCompanyList();
        RepoBaseResponse<Aviokompanii> UpdateCompanyInfo(RepoUpdateCompanyInfoRequest request);
        RepoBaseResponse<Aviokompanii> UpdateCompanyAddressInfo(RepoUpdateCompanyAddressInfoRequest request);

    }
}
