using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class SeatsManager : BaseManager, ISeatsManager
    {
        public SeatsManager() : base() { }
        public SeatsManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        public RepoBaseResponse<Sedishta> AddNewSeat(RepoAddNewSeatRequest request)
        {
            RepoBaseResponse<Sedishta> response = new RepoBaseResponse<Sedishta>();
            try
            {
                Sedishta existingSeat = Context.Sedishta.Where(x => x.BrojNaSediste == request.SeatNumber && x.KlasaId == request.ClassId).FirstOrDefault();
                if (existingSeat != null) response.ReturnedResult = existingSeat;
                else
                {
                    Sedishta newSeat = new Sedishta { BrojNaSediste = request.SeatNumber, KlasaId = request.ClassId };
                    Context.Sedishta.InsertOnSubmit(newSeat);
                    Context.SubmitChanges();
                    response.ReturnedResult = newSeat;
                }
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Sedishta>> GetSeatNumbners(RepoGetSeatNumbnersRequest request)
        {
            RepoBaseResponse<ICollection<Sedishta>> response = new RepoBaseResponse<ICollection<Sedishta>>();
            try
            {
                response.ReturnedResult = Context.Sedishta.Where(x => x.KlasaId == request.ClassId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Sedishta> RemoveSeatIfNotAssigned(RepoRemoveSeatIfNotAssignedRequest request)
        {
            RepoBaseResponse<Sedishta> response = new RepoBaseResponse<Sedishta>();
            try
            {
                Sedishta seat = Context.Sedishta.Where(x => x.KlasaId == request.ClassId && x.SedishteId == request.SeatId).SingleOrDefault();
                if (seat == null)
                    throw new Exception("The seat does not exist");

                if (seat.Rezervaciis_SedishteId.Count != 0)
                    throw new Exception("The account is not deletable");

                this.Context.Sedishta.DeleteOnSubmit(seat);
                Context.SubmitChanges();
                response.ReturnedResult = seat;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
