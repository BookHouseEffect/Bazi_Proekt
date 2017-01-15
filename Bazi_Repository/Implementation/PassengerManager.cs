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
    class PassengerManager : BaseManager, IPassengerManager
    {
        public RepoBaseResponse<bool> AddPassengerAccount(RepoAddPassengerAccountRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Patnici> GetPassengerAccountById(RepoGetPassengerAccountByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Patnici> GetPassengerAccountByPassport(RepoGetPassengerAccountByPassportRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Patnici>> GetPassengersByAccount(RepoGetPassengersByAccountRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Patnici> UpdatePassengerAddressInfo(RepoUpdatePassengerAddressInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Patnici> UpdatePassengerInfo(RepoUpdatePassengerInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Patnici> UpdatePassengerPersonInfo(RepoUpdatePassengerPersonInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
