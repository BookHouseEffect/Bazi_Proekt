using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IScheduleManager
    {
        RepoBaseResponse<ICollection<Rasporedi>> AddNewSchedule(RepoAddNewScheduleRequest request);
        RepoBaseResponse<Rasporedi> GetScheduleById(RepoGetScheduleByIdRequest request);
        RepoBaseResponse<ICollection<Rasporedi>> GetScheduleBySubFlight(RepoGetScheduleBySubFlightRequest request);
        RepoBaseResponse<ICollection<Rasporedi>> GetScheduleByFlight(RepoGetScheduleByFlightRequest request);
        RepoBaseResponse<Rasporedi> UpdateScheduleInfo(RepoUpdateScheduleInfoRequest request);
    }
}
