using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }
        public string? SeatNumber { get; set; }
        public string? Class { get; set; } // Economy, Business, First, etc.
        public Guid FlightId { get; set; }
        [ForeignKey("FlightId")]
        public required Flight Flight { get; set; }
        public bool IsBooked { get; set; } = false; // Default to not booked
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}