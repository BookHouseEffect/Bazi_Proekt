using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bazi_Web.Models
{
    public class PassengerIndexModel
    {
        public ICollection<Patnici> Passenger { get; set; }
        public ICollection<Rezervacii> Tickets { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PassengerId { get; set; }
    }

    public class SearchViewModel
    {
        [Required(ErrorMessage ="Choose source destination")]
        public int SourceAirport { get; set; }

        [Required(ErrorMessage = "Choose targer destination")]
        public int DestinationAirport { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy'-'MM'-'dd}")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Select date")]
        public DateTime Date { get; set; } = new DateTime();

        public IEnumerable<Aerodromi> airports { get; set; }
    }

    public class SearchResultViewModel
    {
        public ICollection<PlanoviNaLetanje> flight { get; set; }
    }

    public class ReservationViewModel
    {
        public PlanoviNaLetanje CurrentFlightScheme { get; set; }
        public IEnumerable<Rezervacii> ReservedList { get; set; }
        public IEnumerable<Patnici> PassengerList { get; set; }
        public List<String> TickerList { get; set; }
        public int PlanId { get; set; }
        public int ClassId { get; set; }

        [Required(ErrorMessage ="Please select a seat")]
        public int SeatNumber { get; set; }

        [Required(ErrorMessage ="Please select a ticket type")]
        public bool TicketType { get; set; }

        [Required(ErrorMessage ="Please select a passenger from your account")]
        public int SelectedPassenger { get; set; }

        public ReservationViewModel()
        {
            this.TickerList = new List<string>();
            TickerList.Add("One way ticket");
            TickerList.Add("Return ticket");
        }
    }
}