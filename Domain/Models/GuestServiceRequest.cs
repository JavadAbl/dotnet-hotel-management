namespace Domain.Models;

public class GuestServiceRequest
{
    public int RequestId { get; set; }
    public int Quantity { get; set; }
    public DateTime RequestDate { get; set; }
    public ServiceRequestStatus Status { get; set; } = ServiceRequestStatus.Pending;
    public string? SpecialInstructions { get; set; }
    public int ReservationId { get; set; }
    public int ServiceId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Reservation? Reservation { get; set; }
    public Service? Service { get; set; }
}
