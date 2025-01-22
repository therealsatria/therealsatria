using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class FlightRoute
    {
        [Key]
        public required Guid Id { get; set; }

        [Required]
        public required Guid OriginAirportId { get; set; }
        [ForeignKey("OriginAirportId")]
        public required Airport OriginAirport { get; set; }

        [Required]
        public required Guid DestinationAirportId { get; set; }
        [ForeignKey("DestinationAirportId")]
        public required Airport DestinationAirport { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialize collection
    }
}