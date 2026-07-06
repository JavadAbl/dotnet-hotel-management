using Domain.Entities.Room.Enums;

namespace Domain.Entities.Room;

public class RoomFeatureAssignment : BaseEntity
{
    public int RoomId { get; set; }
    public int FeatureId { get; set; }
    public DateTime AddedDate { get; set; }
    public AssignmentStatus Status { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Room Room { get; set; } = null!;
    public RoomFeature RoomFeature { get; set; } = null!;
}
