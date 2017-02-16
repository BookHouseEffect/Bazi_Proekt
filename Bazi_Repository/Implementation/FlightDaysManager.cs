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

        public RepoBaseResponse<ICollection<DenoviNaLetanje>> AssignFlightDays(RepoAssignFlightDaysRequest request)
        {
            RepoBaseResponse<ICollection<DenoviNaLetanje>> response = new RepoBaseResponse<ICollection<DenoviNaLetanje>>();
            try
            {
                List<DenoviNaLetanje> flightDays = new List<DenoviNaLetanje>();
                foreach (int den in request.FlightDayList.Distinct())
                    flightDays.Add(new DenoviNaLetanje { LetId = request.FlightId, DenId = den });

                Context.DenoviNaLetanje.InsertAllOnSubmit(flightDays);
                Context.SubmitChanges();

                response.ReturnedResult = flightDays;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<DenoviNaLetanje>> RemoveFlightDays(RepoRemoveFlightDaysRequest request)
        {
            RepoBaseResponse<ICollection<DenoviNaLetanje>> response = new RepoBaseResponse<ICollection<DenoviNaLetanje>>();
            try
            {
                var data = Context.DenoviNaLetanje.Where(x => x.LetId == request.FlightId).ToList();
                Context.DenoviNaLetanje.DeleteAllOnSubmit(data);
                Context.SubmitChanges();

                response.ReturnedResult = data;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
