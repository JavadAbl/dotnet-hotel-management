namespace Domain.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public string TransactionReference { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public int InvoiceId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    public Invoice? Invoice { get; set; }
}
