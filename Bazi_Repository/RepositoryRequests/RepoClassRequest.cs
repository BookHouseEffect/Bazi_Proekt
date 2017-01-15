using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddTypeClassRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
        public IDictionary<String, Int32> ClassNamesAndSeatsNumber { get; set; }

        public RepoAddTypeClassRequest()
        {
            this.ClassNamesAndSeatsNumber = new Dictionary<String, Int32>();
        }
    }

    public class RepoGetTypeClassByIdRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
        public Int32 ClassId { get; set; }
    }

    public class RepoGetTypeClassesRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
    }

    public class RepoUpdateTypeClassNameRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
        public Int32 ClassId { get; set; }
        public String NewName { get; set; }
    }

    public class RepoTransferTypeSeatsIfNotAssignedRequest : RepoBaseRequest
    {
        public Int32 TypeId { get; set; }
        public Int32 OldClass { get; set; }
        public Int32 NewClass { get; set; }
        public Int32 NumberOfSeatsToTransfer { get; set; }
    }
}
