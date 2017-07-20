using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewAddressRequest : RepoBaseRequest
    {
        public Adresi Address { get; set; }
    }

    public class RepoGetAllRegionsRequest : RepoBaseRequest
    {
        public String StateName { get; set; }
    }

    public class RepoGetAllCitiesRequest : RepoBaseRequest
    {
        public String StateName { get; set; }
        public String RegionName { get; set; }
    }

    public class RepoGetAllStreetsRequest : RepoBaseRequest
    {
        public String StateName { get; set; }
        public String RegionName { get; set; }
        public String CityName { get; set; }
    }

    public class RepoCheckIfAddressExistRequest : RepoBaseRequest
    {
        public Adresi Address { get; set; }
    }

    public class RepoUpdateAddressInfoRequest : RepoBaseRequest
    {
        public Int32 AddressId { get; set; }
        public Adresi NewAddress { get; set; }
    }

    public class RepoRemoveUnlikedAddressRequest : RepoBaseRequest
    {
        public Int32 AddressId { get; set; }
    }
}
