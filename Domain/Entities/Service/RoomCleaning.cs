using Domain.Entities.Service.Enums;

namespace Domain.Entities.Service;

public class RoomCleaning : BaseEntity
{
    public int RoomId { get; set; }
    public int StaffId { get; set; }
    public DateTime ScheduledDateTime { get; set; }
    public DateTime? ActualDateTime { get; set; }
    public CleaningStatus Status { get; set; }
    public CleaningType CleaningType { get; set; }
    public string? Notes { get; set; }
    public int? QualityRating { get; set; }
    public int? DurationMinutes { get; set; }
}
