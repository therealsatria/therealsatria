using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Flight Code is required")]
        [StringLength(20, ErrorMessage = "Flight Code cannot exceed 20 characters")]
        public string FlightCode { get; set; }

        [Required(ErrorMessage = "Departure Date is required")]
        public DateTime DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; } // Make nullable

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public Guid AirlineId { get; set; }
        [ForeignKey("AirlineId")]
        public required Airline Airline { get; set; }

        [Required]
        public Guid FlightRouteId { get; set; }
        [ForeignKey("FlightRouteId")]
        public required FlightRoute FlightRoute { get; set; }

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}