using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bazi_Web.Models
{
    public class ListViewModels : FlighViewModes
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class FlighViewModes 
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

    public class AddFlightViewModel : FlighViewModes
    {
        public Letovi Flight { get; set; }
        public ICollection<Megjuletovi> ListOfFlights { get; set; } = new List<Megjuletovi>();

        public ICollection<Int32> DepartureDays { get; set; } = new LinkedList<Int32>();
        public ICollection<TimeSpan> DepartureTime { get; set; } = new LinkedList<TimeSpan>();

        public AddFlightViewModel()
        {
        }

    }

    public class Airports
    {
        public Int32 Number { get; set; }
        public ICollection<Aerodromi> Airs { get; set; }
    }
}