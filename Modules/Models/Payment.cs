using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; } // Credit Card, PayPal, etc. Consider using an enum

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] // Important for decimal precision in the database
        public decimal PaymentAmount { get; set; }

        public Guid BookingId { get; set; }

        [ForeignKey("BookingId")] // Explicitly define the foreign key relationship
        public Booking Booking { get; set; } // Navigation property to Booking
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }
}