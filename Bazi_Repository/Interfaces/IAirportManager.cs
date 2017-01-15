using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IAirportManager
    {
        RepoBaseResponse<Aerodromi> AddNewAirport(RepoAddNewAirportRequest request);
        RepoBaseResponse<Aerodromi> GetAirportById(RepoGetAirportByIdRequest request);
        RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByName(RepoGetAirportsByNameRequest request);
        RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByAddress(RepoGetAirportsByAddressRequest request);
        RepoBaseResponse<Aerodromi> UpdateAirportNameInfo(RepoUpdateAirportNameInfoRequest request);
        RepoBaseResponse<Aerodromi> UpdateAirportAddressInfo(RepoUpdateAirportAddressInfoRequest request);
        RepoBaseResponse<Aerodromi> UpdateAirportLocationInfo(RepoUpdateAirportLocationInfoRequest request);
    }
}
