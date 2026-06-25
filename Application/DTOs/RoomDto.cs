using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class RoomDto
{
    public int RoomId { get; set; }
    
    [Required(ErrorMessage = "Room number is required")]
    [MaxLength(20, ErrorMessage = "Room number cannot exceed 20 characters")]
    public string RoomNumber { get; set; } = string.Empty;
    
    [Range(0, 100, ErrorMessage = "Floor must be between 0 and 100")]
    public int Floor { get; set; }
    
    public RoomStatus Status { get; set; }
    
    [Required(ErrorMessage = "Room type ID is required")]
    public int RoomTypeId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
