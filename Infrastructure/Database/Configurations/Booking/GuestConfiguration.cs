using Domain.Entities.Booking.Enums;
using Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Booking;

public class GuestConfiguration : BaseConfiguration<Guest>
{
    public override void Configure(EntityTypeBuilder<Guest> builder)
    {
        base.Configure(builder);

        builder.ToTable("Guests");

        builder.Property(g => g.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(g => g.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(g => g.Email)
               .IsRequired()
               .HasMaxLength(256);

        builder.Property(g => g.Phone)
               .IsRequired()
               .HasMaxLength(32);

        builder.Property(g => g.Address)
               .HasMaxLength(500);

        builder.Property(g => g.PassportNumber)
               .HasMaxLength(64);

        builder.Property(g => g.Preferences)
               .HasMaxLength(1000);

        builder.Property(g => g.LoyaltyStatus)
               .HasConversion<int>()
               .HasDefaultValue(GuestLoyaltyStatus.Regular);

        builder.HasIndex(g => g.Email)
               .IsUnique();

        builder.HasIndex(g => g.Phone);

        // Full-name convenience index used by reception search screens.
        builder.HasIndex(g => new { g.FirstName, g.LastName });

        builder.HasMany(g => g.Reservations)
               .WithOne()
               .HasForeignKey(r => r.GuestId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(g => g.Reviews)
               .WithOne(r => r.Guest)
               .HasForeignKey(r => r.GuestId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
