using System;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Interfaces
{
    interface ICompanyManager
    {
        RepoBaseResponse<Aviokompanii> RegisterCompany(RepoRegisterCompanyRequest request);
        RepoBaseResponse<Aviokompanii> GetCompanyById(RepoGetCompanyByIdRequest request);
        RepoBaseResponse<ICollection<Aviokompanii>> GetCompaniesByName(RepoGetCompaniesByNameRequest request);
        RepoBaseResponse<ICollection<Aviokompanii>> GetCompanyList(RepoGetCompanyListRequest request);
        RepoBaseResponse<Aviokompanii> UpdateCompanyInfo(RepoUpdateCompanyInfoRequest request);
        RepoBaseResponse<Aviokompanii> UpdateCompanyAddressInfo(RepoUpdateCompanyAddressInfoRequest request);

    }
}
