namespace Domain.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string TransactionReference { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public int InvoiceId { get; set; }
    
    // Navigation property
    public Invoice? Invoice { get; set; }
}
