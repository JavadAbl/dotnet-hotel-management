using Domain.Entities.Staff.Enums;

namespace Domain.Entities.Staff;

public class User : BaseEntity
{
    public int StaffId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public SystemRole SystemRole { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LastLogin { get; set; }

    // Navigation
    public Staff Staff { get; set; } = null!;
}
