using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddPassengerAccountRequest : RepoBaseRequest
    {
        public int AccountId { get; set; }
        public Lugje Person { get; set; }
        public Patnici Passenger { get; set; }
        public Adresi Address { get; set; }
    }

    public class RepoGetPassengerAccountByIdRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 PassengerId { get; set; }
    }

    public class RepoGetPassengerAccountByPassportRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public String PassportNumber { get; set; }
    }

    public class RepoGetPassengersByAccountRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
    }

    public class RepoUpdatePassengerInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 PassengerId { get; set; }
        public Patnici NewPassenger { get; set; }
    }

    public class RepoUpdatePassengerAddressInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 PassengerId { get; set; }
        public Adresi NewAddress { get; set; }
    }

    public class RepoUpdatePassengerPersonInfoRequest : RepoBaseRequest
    {
        public Int32 AccountId { get; set; }
        public Int32 PassengerId { get; set; }
        public Lugje NewPerson { get; set; }
    }
}
