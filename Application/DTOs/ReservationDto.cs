using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class ReservationDto
{
    public int ReservationId { get; set; }
    
    [Required(ErrorMessage = "Check-in date is required")]
    public DateTime CheckInDate { get; set; }
    
    [Required(ErrorMessage = "Check-out date is required")]
    public DateTime CheckOutDate { get; set; }
    
    [Required(ErrorMessage = "Number of guests is required")]
    [Range(1, 20, ErrorMessage = "Number of guests must be between 1 and 20")]
    public int NumberOfGuests { get; set; }
    
    public ReservationStatus Status { get; set; }
    
    [MaxLength(1000, ErrorMessage = "Special requests cannot exceed 1000 characters")]
    public string? SpecialRequests { get; set; }
    
    [Required(ErrorMessage = "Guest ID is required")]
    public int GuestId { get; set; }
    
    [Required(ErrorMessage = "Room ID is required")]
    public int RoomId { get; set; }
    
    public int? StaffId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
