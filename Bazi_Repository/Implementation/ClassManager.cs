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
    class ClassManager : BaseManager, IClassManager
    {
        public RepoBaseResponse<ICollection<Klasi>> AddTypeClass(RepoAddTypeClassRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Klasi> GetTypeClassById(RepoGetTypeClassByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Klasi>> GetTypeClasses(RepoGetTypeClassesRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> TransferTypeSeatsIfNotAssigned(RepoTransferTypeSeatsIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Klasi> UpdateTypeClassName(RepoUpdateTypeClassNameRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
