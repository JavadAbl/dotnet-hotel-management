using Domain.Entities.Service.Enums;

namespace Domain.Entities.Service;

public class Service : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public ServiceType Type { get; set; }

    // Navigation
    public ICollection<ServiceBooking> ServiceBookings { get; set; } = [];
}
