using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Booking
    {
         [Key]
        public Guid Id { get; set; }

        public required DateTime BookingDate { get; set; } = DateTime.Now; // Set default value

        [Required]
        public Guid PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }
        public bool BookingStatus { get; set; }


        

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}