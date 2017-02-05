﻿using Db201617zVaProektRnabContext;
using System;

namespace Bazi_Repository.RepositoryRequests
{
    public class RepoAddNewAirportRequest : RepoBaseRequest
    {
        public String Name { get; set; }
        public Adresi Address { get; set; }
        public Double Latitude { get; set; }
        public Double longitute { get; set; }
    }

    public class RepoGetAirportByIdRequest : RepoBaseRequest
    {
        public Int32 AirportId { get; set; }
    }

    public class RepoGetAirportsByNameRequest : RepoBaseRequest
    {
        public String Name { get; set; }
    }

    public class RepoGetAirportsByAddressRequest : RepoBaseRequest
    {
        public Adresi Address { get; set; }
    }

    public class RepoUpdateAirportNameInfoRequest : RepoBaseRequest
    {
        public Int32 AirportId { get; set; }
        public String NewName { get; set; }
    }

    public class RepoUpdateAirportAddressInfoRequest : RepoBaseRequest
    {
        public Int32 AirportId { get; set; }
        public Adresi NewAddress { get; set; }
    }

    public class RepoUpdateAirportLocationInfoRequest : RepoBaseRequest
    {
        public Int32 AirportId { get; set; }
        public Double NewLongitute { get; set; }
        public Double NewLatitude { get; set; }
    }
}
