namespace Domain.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public DateTime IssueDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
    public int ReservationId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public Reservation? Reservation { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
