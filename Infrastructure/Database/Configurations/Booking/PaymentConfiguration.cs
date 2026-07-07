using Domain.Entities.Booking.Enums;
using Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Booking;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.ToTable("Payments");

        builder.Property(p => p.Amount)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(p => p.PaymentMethod)
               .HasConversion<int>();

        builder.Property(p => p.Currency)
               .HasConversion<int>()
               .HasDefaultValue(Currency.USD);

        builder.Property(p => p.Status)
               .HasConversion<int>()
               .HasDefaultValue(PaymentStatus.Pending);

        builder.Property(p => p.TransactionId)
               .HasMaxLength(128);

        builder.Property(p => p.PaymentDate)
               .IsRequired();

        builder.HasOne(p => p.Reservation)
               .WithMany(r => r.Payments)
               .HasForeignKey(p => p.ReservationId)
               .OnDelete(DeleteBehavior.Cascade);

        // External transaction id should be unique when present (nullable
        // unique indexes are supported by SQL Server / PostgreSQL / SQLite).
        builder.HasIndex(p => p.TransactionId)
               .IsUnique()
               .HasFilter("\"TransactionId\" IS NOT NULL");

        builder.HasIndex(p => p.ReservationId);
        builder.HasIndex(p => p.Status);
        builder.HasIndex(p => p.PaymentDate);
    }
}
