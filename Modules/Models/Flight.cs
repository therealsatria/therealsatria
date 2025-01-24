using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }
        public required string FlightCode { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; } // Make nullable]
        public decimal Price { get; set; }
        public Guid AirlineId { get; set; }
        [ForeignKey("AirlineId")]
        public required Airline Airline { get; set; }
        public Guid FlightRouteId { get; set; }
        [ForeignKey("FlightRouteId")]
        public required FlightRoute FlightRoute { get; set; }
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}