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
    class SeatsManager : BaseManager, ISeatsManager
    {
        public RepoBaseResponse<Sedishta> AddNewSeat(RepoAddNewSeatRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Sedishta>> GetSeatNumbners(RepoGetSeatNumbnersRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Sedishta> RemoveSeatIfNotAssigned(RepoRemoveSeatIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
