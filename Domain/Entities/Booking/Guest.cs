using Domain.Entities.Booking.Enums;

namespace Domain.Entities.Booking;

public class Guest : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? PassportNumber { get; set; }
    public GuestLoyaltyStatus LoyaltyStatus { get; set; }
    public string? Preferences { get; set; }

    // Navigation
    public ICollection<Reservation> Reservations { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
}
