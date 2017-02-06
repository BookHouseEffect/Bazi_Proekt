using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db201617zVaProektRnabContext;

namespace Bazi_Web.Models
{
    public class AirplaneListViewModel
    {
        public ICollection<Avioni> Airplanes { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public AirplaneListViewModel()
        {
            Airplanes = new List<Avioni>();
        }

        public AirplaneListViewModel(ICollection<Avioni> airplanes)
        {
            this.Airplanes = airplanes;
        }
    }

    public class UpdateAirplaneViewModel
    {
        public Avioni Aiplane { get; set; }

        public TipNaAvioni Type { get; set; }

        public ICollection<Klasi> Classes { get; set; }
    }
}