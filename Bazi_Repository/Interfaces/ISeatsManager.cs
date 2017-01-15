using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface ISeatsManager
    {
        RepoBaseResponse<Sedishta> AddNewSeat(RepoAddNewSeatRequest request);
        RepoBaseResponse<Sedishta> RemoveSeatIfNotAssigned(RepoRemoveSeatIfNotAssignedRequest request);
        RepoBaseResponse<ICollection<Sedishta>> GetSeatNumbners(RepoGetSeatNumbnersRequest request);
    }
}
