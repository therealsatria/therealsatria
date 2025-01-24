using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirAccess.Modules.Models
{
    public class Airport
    {
        [Key]
        public Guid Id { get; set; }
        public required string AirportCode { get; set; }
        public required string AirportName { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public ICollection<FlightRoute> OriginatingRoutes { get; set; } = new List<FlightRoute>(); // Initialize collection
        public ICollection<FlightRoute> DestinationRoutes { get; set; } = new List<FlightRoute>(); // Initialize collection
    }
}