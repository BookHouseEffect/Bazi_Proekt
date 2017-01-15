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
    class AirplaneTypeManager : BaseManager, IAirplaneTypeManager
    {
        public RepoBaseResponse<TipNaAvioni> AddNewType(RepoAddNewTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<TipNaAvioni> CheckIfTypeExist(RepoCheckIfTypeExistRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<TipNaAvioni>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<TipNaAvioni> GetTypeById(RepoGetTypeByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> RemoveTypeIfNotAssigned(RepoRemoveTypeIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<TipNaAvioni> UpdateTypeInfoIfNotAssigned(RepoUpdateTypeInfoIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
