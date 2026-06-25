using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class DepartmentDto
{
    public int DepartmentId { get; set; }
    
    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(100, ErrorMessage = "Department name cannot exceed 100 characters")]
    public string DepartmentName { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
