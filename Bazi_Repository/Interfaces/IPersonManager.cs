using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Interfaces
{
    interface IPersonManager
    {
        RepoBaseResponse<Lugje> AddNewPerson(RepoAddNewPersonRequest request);
        RepoBaseResponse<Lugje> GetPersonById(RepoGetPersonByIdRequest request);
        RepoBaseResponse<Lugje> GetPersonByNameOrSurname(RepoGetPersonByNameOrSurnameRequest request);
        RepoBaseResponse<Lugje> GetPersonByIdCardNumber(RepoGetPersonByIdCardNumberRequest request);
        RepoBaseResponse<Lugje> UpdatePersonInfo(RepoUpdatePersonInfoRequest request);
    }
}
