using Domain.Entities.Service.Enums;

namespace Domain.Entities.Service;

public class ServiceBooking : BaseEntity
{
    public int ReservationId { get; set; }
    public int ServiceId { get; set; }
    public int StaffId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime ServiceDate { get; set; }
    public decimal ChargedAmount { get; set; }
    public ServiceBookingStatus Status { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Service Service { get; set; } = null!;
}
