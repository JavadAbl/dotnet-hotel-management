namespace Domain;

public class Invoice
{
    public int InvoiceId { get; set; }
    public DateTime IssueDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ReservationId { get; set; }
    
    // Navigation properties
    public Reservation? Reservation { get; set; }
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
