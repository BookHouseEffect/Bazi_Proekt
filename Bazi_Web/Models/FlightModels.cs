using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Bazi_Web.Models
{
    public class ListViewModels : FlighViewModels
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class FlighViewModels 
    {
        public IEnumerable<SelectListItem> DayList { get; } =
            new List<SelectListItem>() {
                new SelectListItem() {Value = "1", Text = "Monday" },
                new SelectListItem() {Value = "2", Text = "Tuesday" },
                new SelectListItem() {Value = "3", Text = "Wednessday" },
                new SelectListItem() {Value = "4", Text = "Thursday" },
                new SelectListItem() {Value = "5", Text = "Friday" },
                new SelectListItem() {Value = "6", Text = "Saturday" },
                new SelectListItem() {Value = "7", Text = "Sunday" }
            };
    }

    public class FlightListViewModel : ListViewModels {
        public ICollection<Letovi> Flights { get; set; } = new List<Letovi>();
    }

    public class SchemeListViewModel
    {
        public ICollection<PlanoviNaLetanje> Schemes { get; set; }
    }

    public class AddFlightViewModel : FlighViewModels
    {
        public ICollection<Aerodromi> AirportsList { get; set; } = new LinkedList<Aerodromi>();
        public ICollection<Avioni> AirplaneList { get; set; } = new LinkedList<Avioni>();

        public string GetAirportJson()
        {
            List<string> airportsJson = new List<string>();
            foreach (Aerodromi a in AirportsList)
            {
                airportsJson.Add(String.Format("'id':'{0}', 'name':'{1}, {2}, {3}', 'longitude':'{4}', 'latitude':'{5}'",
                    a.AerodromId, a.ImeNaAerodrom, a.Adresi_AdresaId.Grad, a.Adresi_AdresaId.Drzhava, a.GeografskaDolzina, a.GeografskaSirina));
            }

            StringBuilder sb = new StringBuilder("[");
            foreach (string s in airportsJson) {
                if (s != airportsJson.First())
                    sb.Append(",");
                sb.Append("{").Append(s).Append("}");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public string GetAirplaneJson()
        {
            List<string> airplaneJson = new List<string>();
            foreach (Avioni a in AirplaneList)
            {
                StringBuilder s = new StringBuilder();
                s.Append(String.Format("'id':{0}, 'name':'{1} ({2})', 'class':[", a.AvionId, a.ImeNaAvion, a.Registracija));
                foreach (Klasi k in a.TipNaAvioni_TipId.Klasis_TipId)
                {
                    if (k != a.TipNaAvioni_TipId.Klasis_TipId.First())
                        s.Append(",");
                    s.Append("{").Append(String.Format("'id':{0}, 'name':'{1}'", k.KlasaId, k.ImeNaKlasa)).Append("}");
                }
                s.Append("]");
                airplaneJson.Add(s.ToString());
            }

            StringBuilder sb = new StringBuilder("[");
            foreach(string s in airplaneJson)
            {
                if (s != airplaneJson.First())
                    sb.Append(",");
                sb.Append("{").Append(s).Append("}");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }

    public class AddFlightPostModel
    {
        public ICollection<Megjuletovi> ListOfSubFlight { get; set; }
        public ICollection<Int32> ListOfDays { get; set; }
        public ICollection<TimeSpan> ListOfTimes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 AirplaneId { get; set; }
        public ICollection<AddFlightPriceModel> Prices { get; set; }
    }

    public class AddFlightPriceModel
    {
        public Int32 FromId { get; set; }
        public Int32 ToId { get; set; }
        public Int32 ClassId { get; set; }
        public float OneWay { get; set; }
        public float Return { get; set; }
    }

    public class Airports
    {
        public Int32 Number { get; set; }
        public ICollection<Aerodromi> Airs { get; set; }
    }
}