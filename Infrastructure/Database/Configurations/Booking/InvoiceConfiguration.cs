using Domain.Entities.Booking.Enums;
using Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Booking;

public class InvoiceConfiguration : BaseConfiguration<Invoice>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        base.Configure(builder);

        builder.ToTable("Invoices");

        builder.Property(i => i.TotalAmount)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(i => i.TaxAmount)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(i => i.PaymentStatus)
               .HasConversion<int>()
               .HasDefaultValue(InvoicePaymentStatus.Unpaid);

        builder.Property(i => i.IssueDate)
               .IsRequired();

        builder.Property(i => i.DueDate)
               .IsRequired();

        // The Reservation -> Invoice relationship (1-to-0..1) is declared on
        // ReservationConfiguration; here we only add the unique index that
        // enforces the "0..1" side of the relationship at the SQL level.
        builder.HasIndex(i => i.ReservationId)
               .IsUnique();

        builder.HasIndex(i => i.PaymentStatus);
        builder.HasIndex(i => i.DueDate);
    }
}
