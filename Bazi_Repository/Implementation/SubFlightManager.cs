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
    public class SubFlightManager : BaseManager, ISubFlightManager
    {
        public SubFlightManager(): base() { }

        public SubFlightManager(Db201617zVaProektRnabDataContext e): base(e) { }

        private Megjuletovi GetById(Int32 id)
        {
            return Context.Megjuletovi.Where(x => x.MegjuletId == id).SingleOrDefault();
        }

        public RepoBaseResponse<ICollection<Megjuletovi>> AddNewSubFlights(RepoAddNewSubFlightsRequest request)
        {
            RepoBaseResponse<ICollection<Megjuletovi>> response = new RepoBaseResponse<ICollection<Megjuletovi>>();
            try
            {
                foreach (Megjuletovi m in request.SubFlights)
                    m.LetId = request.FlightId;

                Context.Megjuletovi.InsertAllOnSubmit(request.SubFlights);
                Context.SubmitChanges();
                response.ReturnedResult = request.SubFlights;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }

            return response;
        }

        public RepoBaseResponse<Megjuletovi> GetSubFlightById(RepoGetSubFlightByIdRequest request)
        {
            RepoBaseResponse<Megjuletovi> response = new RepoBaseResponse<Megjuletovi>();
            try
            {
                response.ReturnedResult = GetById(request.SubFlightId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }

            return response;
        }

        public RepoBaseResponse<Megjuletovi> RemoveSubFlightIfUnassigned(RepoRemoveSubFlightIfUnassignedRequest request)
        {
            RepoBaseResponse<Megjuletovi> response = new RepoBaseResponse<Megjuletovi>();
            try
            {
                Megjuletovi subflight = GetById(request.SubFlightId);
                if (subflight == null)
                    throw new Exception("The subflight does not exist");

                if (subflight.PlanoviNaLetanjes_MegjuletId.Count != 0
                    || subflight.Rasporedis_MegjuletoviId.Count != 0 )
                    throw new Exception("The subflight is not deletable");

                this.Context.Megjuletovi.DeleteOnSubmit(subflight);
                Context.SubmitChanges();
                response.ReturnedResult = subflight;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Megjuletovi>> GetSubFlightByFlightId(RepoGetSubFlightByFlightIdRequest request)
        {
            RepoBaseResponse<ICollection<Megjuletovi>> response = new RepoBaseResponse<ICollection<Megjuletovi>>();
            try
            {
                response.ReturnedResult = Context.Megjuletovi.Where(x => x.LetId == request.FlightId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }

            return response;
        }
    }
}
