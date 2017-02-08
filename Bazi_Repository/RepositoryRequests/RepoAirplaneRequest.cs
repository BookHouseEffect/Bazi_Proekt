using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddCompanyAirplaneRequest:RepoBaseRequest
    {
        public Int32 CompanyId { get; set; }
        public TipNaAvioni Type { get; set; }
        public String Registry { get; set; }
        public String Name { get; set; }
    }

    public class RepoGetCompanyAirplaneByIdRequest : RepoBaseRequest
    {
        public Int32 CompanyId { get; set; }
        public Int32 AirplaneId { get; set; }
    }

    public class RepoGetCompanyAirplaneByRegistryRequest : RepoBaseRequest
    {
        public Int32 CompanyId { get; set; }
        public String Registry { get; set; }
    }

    public class RepoGetCompanyAirplanesByTypeRequest : RepoPagingBaseRequest
    {
        public Int32 CompanyId { get; set; }
        public TipNaAvioni Type { get; set; }
    }

    public class RepoGetCompanyAirplanesRequest : RepoPagingBaseRequest
    {
        public Int32 CompanyId { get; set; }

    }

    public class RepoUpdateCompanyAirplaneNameRequest : RepoBaseRequest
    {
        public Int32 CompanId { get; set; }
        public Int32 AirplaneId { get; set; }
        public String NewName { get; set; }
    }

    public class RepoUpdateCompanyAirplaneRegistryRequest : RepoBaseRequest
    {
        public Int32 CompanId { get; set; }
        public Int32 AirplaneId { get; set; }
        public String NewRegistry { get; set; }
    }

    public class RepoTransferAirplaneToNewCompanyRequest : RepoBaseRequest
    {
        public Int32 OldCompanyId { get; set; }
        public Int32 NewCompanyId { get; set; }
        public Avioni AirplaneToTransfer { get; set; }
    }
}
