using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class ScheduleManager : BaseManager, IScheduleManager
    {

        public ScheduleManager() : base() { }
        public ScheduleManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Rasporedi GetById(Int32 id)
        {
            return Context.Rasporedi.Where(x => x.RasporedId == id).SingleOrDefault();
        }

        private ICollection<Rasporedi> GetByFlightId(Int32 id)
        {
            return Context.Rasporedi.Where(x => x.MegjuletoviId == id).ToList();
        }

        public RepoBaseResponse<ICollection<Rasporedi>> AddNewSchedule(RepoAddNewScheduleRequest request)
        {
            RepoBaseResponse<ICollection<Rasporedi>> response = new RepoBaseResponse<ICollection<Rasporedi>>();
            try
            {
                List<Rasporedi> schedules = new List<Rasporedi>();
                TimeSpan timeSum = new TimeSpan(0L);
                foreach (Megjuletovi m in request.SubFlights)
                {
                    for (int i = 0; i < request.DeparturesTime.Count; i++)
                    {
                        int day = request.FlightDayList.ElementAt(i);
                        TimeSpan departureTime = request.DeparturesTime.ElementAt(i).Add(timeSum);
                        TimeSpan arrivalTime = departureTime.Add(m.VremeNaLetanje);

                        schedules.Add(new Rasporedi() {
                            MegjuletoviId = m.MegjuletId,
                            DenNaPoletuvanje = day,
                            VremeNaPoletuvanje = departureTime,
                            DenNaSletuvanje = arrivalTime.Days == 1 ? day % 7 + 1 : day,
                            VremeNaSletuvanje = arrivalTime.Subtract(new TimeSpan(arrivalTime.Days, 0, 0, 0))
                        });
                    }
                    timeSum = timeSum.Add(m.VremeNaLetanje).Add(request.RequiredWaitingInterval);
                }

                Context.Rasporedi.InsertAllOnSubmit(schedules);
                Context.SubmitChanges();
                response.ReturnedResult = schedules;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Rasporedi>> GetScheduleByFlight(RepoGetScheduleByFlightRequest request)
        {
            RepoBaseResponse<ICollection<Rasporedi>> response = new RepoBaseResponse<ICollection<Rasporedi>>();
            try
            {
                SubFlightManager subFlightManager = new SubFlightManager(this.Context);
                RepoBaseResponse<ICollection<Megjuletovi>> subFlightResponse =  subFlightManager
                    .GetSubFlightByFlightId(new RepoGetSubFlightByFlightIdRequest { FlightId = request.FlightId });
                if (subFlightResponse.HasError()) throw subFlightResponse.Exception;

                List<Rasporedi> schedules = new List<Rasporedi>();
                foreach (Megjuletovi m in subFlightResponse.ReturnedResult)
                    schedules.AddRange(GetByFlightId(m.MegjuletId));
                response.ReturnedResult = schedules;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Rasporedi> GetScheduleById(RepoGetScheduleByIdRequest request)
        {
            RepoBaseResponse<Rasporedi> response = new RepoBaseResponse<Rasporedi>();
            try
            {
                response.ReturnedResult = GetById(request.ScheduleId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Rasporedi>> GetScheduleBySubFlight(RepoGetScheduleBySubFlightRequest request)
        {
            RepoBaseResponse<ICollection<Rasporedi>> response = new RepoBaseResponse<ICollection<Rasporedi>>();
            try
            {
                response.ReturnedResult = GetByFlightId(request.SubFlightId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Rasporedi> UpdateScheduleInfo(RepoUpdateScheduleInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
