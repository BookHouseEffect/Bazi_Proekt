using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoRegisterCompanyRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public String CompanyName { get; set; }
        public Adresi Address { get; set; }
    }

    public class RepoGetCompanyByIdRequest : RepoBaseRequest
    {
        public Int32 Id { get; set; }
    }

    public class RepoGetCompanyByNameRequest : RepoBaseRequest
    {
        public String CompanyName { get; set; }
    }

    public class RepoUpdateCompanyInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 CompanyId { get; set; }
        public String NewCompanyName { get; set; }
    }

    public class RepoUpdateCompanyAddressInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 CompanyId { get; set; }
        public Adresi NewAddress { get; set; }
    }
}
