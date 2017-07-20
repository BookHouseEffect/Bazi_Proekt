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
    public class PriceManager : BaseManager, IPriceManager
    {
        public RepoBaseResponse<ICollection<Cenovnici>> AddNewFlightPrice(RepoAddNewFlightPriceRequest request)
        {
            RepoBaseResponse<ICollection<Cenovnici>> response = new RepoBaseResponse<ICollection<Cenovnici>>();
            try
            {
                Context.Cenovnici.InsertAllOnSubmit(request.PriceList);
                Context.SubmitChanges();
                response.ReturnedResult = request.PriceList;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Cenovnici>> GetPriceListByFlightSCheme(RepoGetPriceListByFlightSChemeRequest request)
        {
            RepoBaseResponse<ICollection<Cenovnici>> response = new RepoBaseResponse<ICollection<Cenovnici>>();
            try
            {
                response.ReturnedResult = Context.Cenovnici.Where(x => x.PlanId == request.FlightSchemeId).ToList();
            }
            catch (Exception ex )
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Cenovnici> GetPriceListById(RepoGetPriceListByIdRequest request)
        {
            RepoBaseResponse<Cenovnici> response = new RepoBaseResponse<Cenovnici>();
            try
            {
                response.ReturnedResult = Context.Cenovnici.Where(x => x.CenovnikId == request.PriceListId).SingleOrDefault();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Cenovnici> UpdatePriceInfo(RepoUpdatePriceInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
