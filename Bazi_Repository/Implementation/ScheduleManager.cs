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
    class ScheduleManager : BaseManager, IScheduleManager
    {
        public RepoBaseResponse<Rasporedi> AddNewSchedule(RepoAddNewScheduleRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Rasporedi>> GetScheduleByFlight(RepoGetScheduleByFlightRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Rasporedi> GetScheduleById(RepoGetScheduleByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Rasporedi>> GetScheduleBySubFlight(RepoGetScheduleBySubFlightRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Rasporedi> UpdateScheduleInfo(RepoUpdateScheduleInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
