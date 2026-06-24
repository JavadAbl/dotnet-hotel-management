namespace Domain.Models;
public class MaintenanceRequest
{
    public int MaintenanceId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ReportedDate { get; set; }
    public int RoomId { get; set; }
    public int StaffId { get; set; }
    
    // Navigation properties
    public Room? Room { get; set; }
    public Staff? Staff { get; set; }
}
