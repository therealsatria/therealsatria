using System.ComponentModel.DataAnnotations;

namespace AirAccess.Modules.Models
{
    public class Airline
    {
        [Key]
        public Guid Id { get; set; }
        public required string AirlineName { get; set; }
        public required string AirlineCode { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialize collection
    }
}