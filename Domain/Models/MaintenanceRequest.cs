namespace Domain.Models;

public class MaintenanceRequest
{
    public int MaintenanceId { get; set; }
    public string Description { get; set; } = string.Empty;
    public MaintenancePriority Priority { get; set; } = MaintenancePriority.Medium;
    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Pending;
    public DateTime ReportedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string? ResolutionNotes { get; set; }
    public int RoomId { get; set; }
    public int StaffId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Room? Room { get; set; }
    public Staff? Staff { get; set; }
}
