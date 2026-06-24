using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class InvoiceDto
{
    public int InvoiceId { get; set; }
    
    [Required(ErrorMessage = "Issue date is required")]
    public DateTime IssueDate { get; set; }
    
    [Required(ErrorMessage = "Subtotal is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Subtotal cannot be negative")]
    public decimal SubTotal { get; set; }
    
    [Required(ErrorMessage = "Tax amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Tax amount cannot be negative")]
    public decimal TaxAmount { get; set; }
    
    [Required(ErrorMessage = "Total amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Total amount cannot be negative")]
    public decimal TotalAmount { get; set; }
    
    public InvoiceStatus Status { get; set; }
    
    [Required(ErrorMessage = "Reservation ID is required")]
    public int ReservationId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}
