using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IPersonManager
    {
        RepoBaseResponse<Lugje> AddNewPerson(RepoAddNewPersonRequest request);
        RepoBaseResponse<Lugje> GetPersonById(RepoGetPersonByIdRequest request);
        RepoBaseResponse<ICollection<Lugje>> GetPersonByNameOrSurname(RepoGetPersonByNameOrSurnameRequest request);
        RepoBaseResponse<Lugje> GetPersonByIdCardNumber(RepoGetPersonByIdCardNumberRequest request);
        RepoBaseResponse<Lugje> UpdatePersonInfo(RepoUpdatePersonInfoRequest request);
        RepoBaseResponse<Lugje> RemoveUnlinkedPerson(RepoRemoveUnlinkedPersonRequest request);
    }
}
