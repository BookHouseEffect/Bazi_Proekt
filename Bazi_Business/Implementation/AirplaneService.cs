using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Business.Interfaces;
using Bazi_Business.Requests;
using Bazi_Business.Responses;
using Bazi_Repository.Implementation;
using Bazi_Repository.RepositoryRequests;
using Bazi_Repository;
using Db201617zVaProektRnabContext;
using System.Net;

namespace Bazi_Business.Implementation
{
    public class AirplaneService : IAirplaneService
    {
        public GetAirplaneListResponse GetAirplaneList(GetAirplanesListRequest request)
        {
            GetAirplaneListResponse response = new GetAirplaneListResponse();
            try
            {
                AirplaneManager airplaneManager = new AirplaneManager();
                RepoBaseResponse<ICollection<Avioni>> airResponse = airplaneManager.GetCompanyAirplanes(new RepoGetCompanyAirplanesRequest
                {
                    CompanyId = request.CompanyId, PageNumber = request.PageNumber, PageSize = request.PageSize
                });
                if (airResponse.Status != HttpStatusCode.OK || airResponse.ReturnedResult == null)
                    throw airResponse.Exception;

                response.Airplanes = airResponse.ReturnedResult;
            } catch (Exception ex)
            {
                response.SetInternalServerErrorMessage(ex);
            }
            return response;
        }
    }
}
