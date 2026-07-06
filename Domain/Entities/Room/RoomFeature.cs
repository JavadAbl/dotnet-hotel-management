using Domain.Entities.Room.Enums;

namespace Domain.Entities.Room;

public class RoomFeature : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public FeatureCategory Category { get; set; }
    public bool IsStandard { get; set; }
    public decimal AdditionalCost { get; set; }
    public bool IsAvailable { get; set; }

    // Navigation
    public ICollection<RoomFeatureAssignment> RoomFeatureAssignments { get; set; } = [];
}
