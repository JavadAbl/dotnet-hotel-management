using Domain.Entities.Booking.Enums;

namespace Domain.Entities.Booking;

public class Reservation : BaseEntity
{
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public int NumberOfNights { get; set; }
    public ReservationStatus Status { get; set; }
    public string? SpecialRequests { get; set; }
    public BookingSource BookingSource { get; set; }

    // Navigation
    public Guest Guest { get; set; } = null!;
    public ICollection<Payment> Payments { get; set; } = [];
    public Invoice Invoice { get; set; } = null!;
    public Review Review { get; set; } = null!;
}
