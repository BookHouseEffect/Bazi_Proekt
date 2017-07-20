using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IPassengerManager
    {
        RepoBaseResponse<Patnici> AddPassengerAccount(RepoAddPassengerAccountRequest request);
        RepoBaseResponse<Patnici> GetPassengerAccountById(RepoGetPassengerAccountByIdRequest request);
        RepoBaseResponse<Patnici> GetPassengerAccountByPassport(RepoGetPassengerAccountByPassportRequest request);
        RepoBaseResponse<ICollection<Patnici>> GetPassengersByAccount(RepoGetPassengersByAccountRequest request);
        RepoBaseResponse<Patnici> UpdatePassengerInfo(RepoUpdatePassengerInfoRequest request);
        RepoBaseResponse<Patnici> UpdatePassengerAddressInfo(RepoUpdatePassengerAddressInfoRequest request);
        RepoBaseResponse<Patnici> UpdatePassengerPersonInfo(RepoUpdatePassengerPersonInfoRequest request);
    }
}
