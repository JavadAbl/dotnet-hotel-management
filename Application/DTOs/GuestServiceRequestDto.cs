using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class GuestServiceRequestDto
{
    public int RequestId { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Request date is required")]
    public DateTime RequestDate { get; set; }
    
    public ServiceRequestStatus Status { get; set; }
    
    [MaxLength(500, ErrorMessage = "Special instructions cannot exceed 500 characters")]
    public string? SpecialInstructions { get; set; }
    
    [Required(ErrorMessage = "Reservation ID is required")]
    public int ReservationId { get; set; }
    
    [Required(ErrorMessage = "Service ID is required")]
    public int ServiceId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
