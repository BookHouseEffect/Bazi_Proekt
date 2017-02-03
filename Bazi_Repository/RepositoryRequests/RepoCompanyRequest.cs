﻿using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoRegisterCompanyRequest : RepoBaseRequest
    {
        public Akaunti Account { get; set; }
        public String CompanyName { get; set; }
        public Adresi Address { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp { get; set; }
    }

    public class RepoGetCompanyByIdRequest : RepoBaseRequest
    {
        public Int32 Id { get; set; }
    }

    public class RepoGetCompaniesByNameRequest : RepoBaseRequest
    {
        public String CompanyName { get; set; }
    }

    public class RepoGetCompanyListRequest : RepoBaseRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
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
