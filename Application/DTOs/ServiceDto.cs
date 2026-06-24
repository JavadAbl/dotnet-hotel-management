using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ServiceDto
{
    public int ServiceId { get; set; }
    
    [Required(ErrorMessage = "Service name is required")]
    [MaxLength(100, ErrorMessage = "Service name cannot exceed 100 characters")]
    public string ServiceName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
    public decimal UnitPrice { get; set; }
    
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
