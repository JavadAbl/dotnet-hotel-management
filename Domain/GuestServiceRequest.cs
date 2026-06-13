namespace Domain;

public class GuestServiceRequest
{
    public int RequestId { get; set; }
    public int Quantity { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ReservationId { get; set; }
    public int ServiceId { get; set; }
    
    // Navigation properties
    public Reservation? Reservation { get; set; }
    public Service? Service { get; set; }
}
