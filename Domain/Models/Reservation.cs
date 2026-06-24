namespace Domain.Models;

public class Reservation
{
    public int ReservationId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public string? SpecialRequests { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public int? StaffId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Guest? Guest { get; set; }
    public Room? Room { get; set; }
    public Staff? Staff { get; set; }
    public Invoice? Invoice { get; set; }
    public ICollection<GuestServiceRequest> GuestServiceRequests { get; set; } = new List<GuestServiceRequest>();
}
