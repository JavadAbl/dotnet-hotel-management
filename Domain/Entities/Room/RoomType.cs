namespace Domain.Entities.Room;

public class RoomType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public string? Description { get; set; }
    public int MaxOccupancy { get; set; }
    public string? StandardAmenities { get; set; }

    // Navigation
    public ICollection<Room> Rooms { get; set; } = [];
}
