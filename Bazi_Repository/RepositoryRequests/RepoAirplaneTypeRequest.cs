using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewTypeRequest : RepoBaseRequest
    {
        public TipNaAvioni Type { get; set; }
    }

    public class RepoGetTypeByIdRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
    }

    public class RepoCheckIfTypeExistRequest : RepoBaseRequest
    {
        public TipNaAvioni Type { get; set; }
    }

    public class RepoUpdateTypeInfoIfNotAssignedRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
        public TipNaAvioni NewType { get; set; }
    }

    public class RepoRemoveTypeIfNotAssignedRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
    }
}
