namespace Domain.Entities.Booking;

public class Review : BaseEntity
{
    public int GuestId { get; set; }
    public int ReservationId { get; set; }
    public int Rating { get; set; }
    public string? Comments { get; set; }
    public DateTime ReviewDate { get; set; }

    // Navigation
    public Guest Guest { get; set; } = null!;
    public Reservation Reservation { get; set; } = null!;
}
