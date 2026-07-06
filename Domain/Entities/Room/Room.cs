using Domain.Entities.Room.Enums;

namespace Domain.Entities.Room;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public int TypeId { get; set; }
    public int FloorNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public RoomStatus Status { get; set; }
    public int Capacity { get; set; }
    public string? Amenities { get; set; }

    // Navigation
    public RoomType RoomType { get; set; } = null!;
    public ICollection<RoomFeatureAssignment> RoomFeatureAssignments { get; set; } = [];
}
