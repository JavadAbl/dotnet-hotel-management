using Domain.Entities.Booking.Enums;

namespace Domain.Entities.Booking;

public class Invoice : BaseEntity
{
    public int ReservationId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public InvoicePaymentStatus PaymentStatus { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }

    // Navigation
    public Reservation Reservation { get; set; } = null!;
}
