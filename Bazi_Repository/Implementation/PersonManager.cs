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
    class PersonManager : BaseManager, IPersonManager
    {
        public RepoBaseResponse<Lugje> AddNewPerson(RepoAddNewPersonRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Lugje> GetPersonById(RepoGetPersonByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Lugje> GetPersonByIdCardNumber(RepoGetPersonByIdCardNumberRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Lugje> GetPersonByNameOrSurname(RepoGetPersonByNameOrSurnameRequest request)
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<Lugje> UpdatePersonInfo(RepoUpdatePersonInfoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
