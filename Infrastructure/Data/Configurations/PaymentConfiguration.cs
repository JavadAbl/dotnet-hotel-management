using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        
        builder.HasKey(p => p.PaymentId);
        
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.TransactionReference)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(p => p.PaymentDate)
            .IsRequired();
        
        builder.Property(p => p.InvoiceId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(p => p.Invoice)
            .WithMany(i => i.Payments)
            .HasForeignKey(p => p.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
