using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class MaintenanceRequestDto
{
    public int MaintenanceId { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;
    
    public MaintenancePriority Priority { get; set; }
    
    public MaintenanceStatus Status { get; set; }
    
    [Required(ErrorMessage = "Reported date is required")]
    public DateTime ReportedDate { get; set; }
    
    public DateTime? CompletedDate { get; set; }
    
    [MaxLength(500, ErrorMessage = "Resolution notes cannot exceed 500 characters")]
    public string? ResolutionNotes { get; set; }
    
    [Required(ErrorMessage = "Room ID is required")]
    public int RoomId { get; set; }
    
    [Required(ErrorMessage = "Staff ID is required")]
    public int StaffId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
