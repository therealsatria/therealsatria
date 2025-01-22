using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Seat Number is required")]
        [StringLength(10, ErrorMessage = "Seat Number cannot exceed 10 characters")]
        public string SeatNumber { get; set; }

        [Required(ErrorMessage = "Class is required")]
        [StringLength(20, ErrorMessage = "Class cannot exceed 20 characters")]
        public string Class { get; set; } // Economy, Business, First, etc.

        [Required]
        public Guid FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public bool IsBooked { get; set; } = false; // Default to not booked

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}