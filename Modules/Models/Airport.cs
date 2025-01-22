using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirAccess.Modules.Models
{
    public class Airport
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Airport Code is required")]
        [StringLength(3, ErrorMessage = "Airport Code must be 3 characters")] // IATA codes are 3 characters
        public required string AirportCode { get; set; }

        [Required(ErrorMessage = "Airport Name is required")]
        [StringLength(100, ErrorMessage = "Airport Name cannot exceed 100 characters")]
        public required string AirportName { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public required string City { get; set; }
        public required string Country { get; set; }

        public ICollection<FlightRoute> OriginatingRoutes { get; set; } = new List<FlightRoute>(); // Initialize collection
        public ICollection<FlightRoute> DestinationRoutes { get; set; } = new List<FlightRoute>(); // Initialize collection
    }
}