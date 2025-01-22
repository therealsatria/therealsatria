using System;
using System.ComponentModel.DataAnnotations;

namespace AirAccess.Modules.Models
{
    public class Passenger
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "ID Number is required")]
        [StringLength(50, ErrorMessage = "ID Number cannot exceed 50 characters")]
        public required string IdNumber { get; set; }

        [StringLength(20, ErrorMessage = "Phone Number cannot exceed 20 characters")]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public required string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Initialize collection
    }
}