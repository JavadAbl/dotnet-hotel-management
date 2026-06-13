using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");
        
        builder.HasKey(i => i.InvoiceId);
        
        builder.Property(i => i.IssueDate)
            .IsRequired();
        
        builder.Property(i => i.SubTotal)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(i => i.TaxAmount)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(i => i.TotalAmount)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(i => i.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(i => i.ReservationId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(i => i.Reservation)
            .WithOne(r => r.Invoice)
            .HasForeignKey<Invoice>(i => i.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(i => i.Payments)
            .WithOne(p => p.Invoice)
            .HasForeignKey(p => p.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
