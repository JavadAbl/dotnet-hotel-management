using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs;

public class PaymentDto
{
    public int PaymentId { get; set; }
    
    [Required(ErrorMessage = "Amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    
    [MaxLength(100, ErrorMessage = "Transaction reference cannot exceed 100 characters")]
    public string? TransactionReference { get; set; }
    
    [Required(ErrorMessage = "Payment date is required")]
    public DateTime PaymentDate { get; set; }
    
    [Required(ErrorMessage = "Invoice ID is required")]
    public int InvoiceId { get; set; }
    
    public DateTime CreatedAt { get; set; }
}
