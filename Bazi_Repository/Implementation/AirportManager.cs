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
    public class AirportManager : BaseManager, IAirportManager
    {
        public RepoBaseResponse<Aerodromi> AddNewAirport(RepoAddNewAirportRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aerodromi> GetAirportById(RepoGetAirportByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByAddress(RepoGetAirportsByAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByName(RepoGetAirportsByNameRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportAddressInfo(RepoUpdateAirportAddressInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportLocationInfo(RepoUpdateAirportLocationInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportNameInfo(RepoUpdateAirportNameInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public ICollection<Aerodromi> GetAirports()
        {
            return Context.Aerodromi.ToList();
        }
    }
}
