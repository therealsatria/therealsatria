using System;
using System.ComponentModel.DataAnnotations;

namespace AirAccess.Modules.Models
{
    public class Passenger
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string IdNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Initialize collection
    }
}