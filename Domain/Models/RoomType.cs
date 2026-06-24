namespace Domain.Models;

public class RoomType
{
    public int RoomTypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public int MaxOccupancy { get; set; }
    public string BedType { get; set; } = string.Empty;
    public string Amenities { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
