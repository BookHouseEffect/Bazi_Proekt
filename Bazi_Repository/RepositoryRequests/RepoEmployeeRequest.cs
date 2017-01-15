using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddEmployeeAccountRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Lugje Person { get; set; }
        public Vraboteni Employee { get; set; }
        public Aviokompanii Company { get; set; }
    }

    public class RepoGetEmployeeAccountByIdRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 EmployeeId { get; set; }
    }

    public class RepoGetEmployeesByCompanyRequest : RepoBaseRequest
    {
        public Int32 CompanyId { get; set; }
    }

    public class RepoUpdateEmployeeInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 EmployeeId { get; set; }
        public Int32 CompanyId { get; set; }
        public Vraboteni NewEmployee { get; set; }
    }

    public class RepoUpdateEmployeePersonInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 EmployeeId { get; set; }
        public Int32 CompanyId { get; set; }
        public Lugje NewPerson { get; set; }
    }
}
