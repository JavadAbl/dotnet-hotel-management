using Domain.Entities.Booking.Enums;

namespace Domain.Entities.Booking;

public class Payment : BaseEntity
{
    public int ReservationId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Currency Currency { get; set; }
    public PaymentStatus Status { get; set; }
    public string? TransactionId { get; set; }
    public DateTime PaymentDate { get; set; }

    // Navigation
    public Reservation Reservation { get; set; } = null!;
}
