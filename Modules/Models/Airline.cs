using System.ComponentModel.DataAnnotations;

namespace AirAccess.Modules.Models
{
    public class Airline
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Airline Name is required")]
        [StringLength(100, ErrorMessage = "Airline Name cannot exceed 100 characters")]
        public required string AirlineName { get; set; }
        public required string AirlineCode { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialize collection
    }
}