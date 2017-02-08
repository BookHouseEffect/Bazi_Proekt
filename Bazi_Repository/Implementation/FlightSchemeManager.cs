using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class FlightSchemeManager : BaseManager, IFlightSchemeManager
    {
        public RepoBaseResponse<ICollection<PlanoviNaLetanje>> AddNewFlightScheme(RepoAddNewFlightSchemeRequest request)
        {
            RepoBaseResponse<ICollection<PlanoviNaLetanje>> response = new RepoBaseResponse<ICollection<PlanoviNaLetanje>>();
            ScheduleManager scheduleManager = new ScheduleManager(this.Context);
            try
            {
                var listDates = Enumerable.Range(0, int.MaxValue).Select(index => 
                    new DateTime?(request.StartDate.AddDays(index)))
                    .TakeWhile(date => date <= request.EndDate).ToList();

                List<PlanoviNaLetanje> plans = new List<PlanoviNaLetanje>();
                foreach(Megjuletovi m in request.SubFlight)
                {
                    RepoBaseResponse<ICollection<Rasporedi>> scheduleResponse = scheduleManager.GetScheduleBySubFlight(new RepoGetScheduleBySubFlightRequest { SubFlightId = m.MegjuletId });
                    if (scheduleResponse.HasError()) throw scheduleResponse.Exception;

                    foreach (Rasporedi r in scheduleResponse.ReturnedResult)
                    {
                        var goDays = listDates.Where(x => (int)x.Value.DayOfWeek == r.DenNaPoletuvanje).ToList();

                        for(int i=0; i<goDays.Count(); i++)
                        {
                            DateTime t1 = goDays.ElementAt(i).Value.AddHours(r.VremeNaPoletuvanje.Hours).AddMinutes(r.VremeNaPoletuvanje.Minutes);
                            DateTime t2 = goDays.ElementAt(i).Value.AddDays(r.DenNaPoletuvanje == r.DenNaSletuvanje ? 0 : 1).AddHours(r.VremeNaSletuvanje.Hours).AddMinutes(r.VremeNaSletuvanje.Minutes);
                            plans.Add(new PlanoviNaLetanje()
                            {
                                AvionId = request.AirplaneId,
                                DatumVremeNaPoletuvanje = t1,
                                DatumVremeNaSletuvanje = t2,
                                MegjuletId = m.MegjuletId,
                                Vremetraenje = t2 - t1,
                                StatusNaLetot = request.Status
                            });
                        }
                    }
                }
                Context.PlanoviNaLetanje.InsertAllOnSubmit(plans);
                Context.SubmitChanges();
                response.ReturnedResult = plans;
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<PlanoviNaLetanje> GetFlightSchemeById(RepoGetFlightSchemeByIdRequest request)
        {
            RepoBaseResponse<PlanoviNaLetanje> response = new RepoBaseResponse<PlanoviNaLetanje>();
            try
            {
                response.ReturnedResult = Context.PlanoviNaLetanje.Where(x => x.PlanId == request.FlightSchemeId).SingleOrDefault();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<PlanoviNaLetanje>> GetFlightSchemesBySubFlight(RepoGetFlightSchemesBySubFlightRequest request)
        {
            RepoBaseResponse<ICollection<PlanoviNaLetanje>> response = new RepoBaseResponse<ICollection<PlanoviNaLetanje>>();
            try
            {
                response.ReturnedResult = Context.PlanoviNaLetanje.Where(x => x.MegjuletId == request.SubflightId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<PlanoviNaLetanje> UpdateFlightSchemeInfo(RepoUpdateFlightSchemeInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
