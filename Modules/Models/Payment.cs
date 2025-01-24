using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirAccess.Modules.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Credit Card, PayPal, etc. Consider using an enum
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public Guid BookingId { get; set; }
        [ForeignKey("BookingId")] 
        public required Booking Booking { get; set; } // Navigation property to Booking
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }
}