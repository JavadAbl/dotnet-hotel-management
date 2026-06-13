namespace Domain;

public class Service
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    
    // Navigation property
    public ICollection<GuestServiceRequest> GuestServiceRequests { get; set; } = new List<GuestServiceRequest>();
}
