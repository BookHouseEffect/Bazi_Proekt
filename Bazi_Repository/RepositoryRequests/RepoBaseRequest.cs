using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoBaseRequest
    {
    }

    public class RepoPagingBaseRequest : RepoBaseRequest
    {
        public Int32 PageNumber { get; set; } = 1;
        public Int32 PageSize { get; set; } = 10;
    }
}
