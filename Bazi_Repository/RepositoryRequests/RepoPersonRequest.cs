using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewPersonRequest : RepoBaseRequest
    {
        public Lugje Person { get; set; }
    }

    public class RepoGetPersonByIdRequest : RepoBaseRequest
    {
        public Int32 PersonId { get; set; }
    }

    public class RepoGetPersonByNameOrSurnameRequest : RepoBaseRequest
    {
        public String Name { get; set; }
        public String Surname { get; set; }
    }

    public class RepoGetPersonByIdCardNumberRequest : RepoBaseRequest
    {
        public String IdCardNumber { get; set; }
    }

    public class RepoUpdatePersonInfoRequest : RepoBaseRequest
    {
        public Int32 PersonId { get; set; }
        public Lugje NewPerson { get; set; }
    }
}
