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
    public class FlightManager : BaseManager, IFlightManager
    {
        public RepoBaseResponse<Letovi> AddNewFlight(RepoAddNewFlightRequest request)
        {
            RepoBaseResponse<Letovi> response = new RepoBaseResponse<Letovi>();

            Letovi let = new Letovi() { KompanijaId = request.CompanyId, Status = "aktiven" };
            Context.Letovi.InsertOnSubmit(let);
            Context.SubmitChanges();

            foreach (int den in request.FlightDayList.Distinct())
            {
                DenoviNaLetanje denovi = new DenoviNaLetanje { LetId = let.LetId, DenId = den };
                Context.DenoviNaLetanje.InsertOnSubmit(denovi);
                Context.SubmitChanges();
            }

            int last = 0;
            TimeSpan lastMinuteSum = new TimeSpan(0L);
            foreach(Megjuletovi m in request.SubFlightList)
            {
                m.LetId = let.LetId;
                if (last != 0)
                    m.AerodromOdId = last;
                last = m.AerodromDoId;
                Context.Megjuletovi.InsertOnSubmit(m);
                Context.SubmitChanges();

                for (int i=0; i<request.FlightDayList.Count; i++)
                {
                    int den = request.FlightDayList.ElementAt(i);
                    TimeSpan time = request.DeparturesTime.ElementAt(i);
                    TimeSpan nextTime = time.Add(m.VremeNaLetanje).Add(lastMinuteSum);

                    Rasporedi r = new Rasporedi()
                    {
                        MegjuletoviId = m.MegjuletId,
                        DenNaPoletuvanje = den,
                        VremeNaPoletuvanje = time,
                        DenNaSletuvanje = nextTime.Days == 1 ? den % 7 + 1 : den,
                        VremeNaSletuvanje = nextTime.Subtract(new TimeSpan(nextTime.Days, 0,0,0))
                    };
                    Context.Rasporedi.InsertOnSubmit(r);
                    Context.SubmitChanges();
                }
                lastMinuteSum = lastMinuteSum.Add(m.VremeNaLetanje);
            }
            Context.Refresh(Devart.Data.Linq.RefreshMode.OverwriteCurrentValues, let);
            response.ReturnedResult = let;
            return response;
        }

        public RepoBaseResponse<Letovi> GetFlightById(RepoGetFlightByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<bool> RemoveFlightIfNotAssigned(RepoRemoveFlightIfNotAssignedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
