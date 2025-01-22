using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ticket Number is required")]
        public string TicketNumber { get; set; }

        
        public Guid BookingId { get; set; }
        [ForeignKey("BookingId")]
        public required Booking Booking { get; set; }

        public Guid SeatId { get; set; }
        [ForeignKey("SeatId")]
        public required Seat Seat { get; set; }

    }
}