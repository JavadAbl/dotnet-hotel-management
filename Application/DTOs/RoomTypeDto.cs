using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class RoomTypeDto
{
    public int RoomTypeId { get; set; }
    
    [Required(ErrorMessage = "Type name is required")]
    [MaxLength(100, ErrorMessage = "Type name cannot exceed 100 characters")]
    public string TypeName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Base price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Base price must be greater than 0")]
    public decimal BasePrice { get; set; }
    
    [Required(ErrorMessage = "Max occupancy is required")]
    [Range(1, 20, ErrorMessage = "Max occupancy must be between 1 and 20")]
    public int MaxOccupancy { get; set; }
    
    [Required(ErrorMessage = "Bed type is required")]
    [MaxLength(50, ErrorMessage = "Bed type cannot exceed 50 characters")]
    public string BedType { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Amenities description cannot exceed 500 characters")]
    public string? Amenities { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
