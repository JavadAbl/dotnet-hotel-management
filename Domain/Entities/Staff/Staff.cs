using Domain.Entities.Staff.Enums;

namespace Domain.Entities.Staff;

public class Staff : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public OperationalRole OperationalRole { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string ShiftSchedule { get; set; } = string.Empty;
    public string? OperationalPermissions { get; set; }

    // Navigation
    public User User { get; set; } = null!;
}
