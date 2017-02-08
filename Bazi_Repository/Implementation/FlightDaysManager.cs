using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.Interfaces;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class FlightDaysManager : BaseManager, IFlightDaysManager
    {

        public FlightDaysManager() : base(){ }
        public FlightDaysManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        public RepoBaseResponse<DenoviNaLetanje> AssignFlightDays(RepoAssignFlightDaysRequest request)
        {
            RepoBaseResponse<DenoviNaLetanje> response = new RepoBaseResponse<DenoviNaLetanje>();
            try
            {
                List<DenoviNaLetanje> flightDays = new List<DenoviNaLetanje>();
                foreach (int den in request.FlightDayList.Distinct())
                    flightDays.Add(new DenoviNaLetanje { LetId = request.FlightId, DenId = den });

                Context.DenoviNaLetanje.InsertAllOnSubmit(flightDays);
                Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
