using Domain.Entities.Booking.Enums;
using Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Booking;

public class ReservationConfiguration : BaseConfiguration<Reservation>
{
    public override void Configure(EntityTypeBuilder<Reservation> builder)
    {
        base.Configure(builder);

        builder.ToTable("Reservations");

        builder.Property(r => r.CheckInDate)
               .IsRequired();

        builder.Property(r => r.CheckOutDate)
               .IsRequired();

        builder.Property(r => r.NumberOfNights)
               .IsRequired();

        builder.Property(r => r.Status)
               .HasConversion<int>()
               .HasDefaultValue(ReservationStatus.Pending);

        builder.Property(r => r.BookingSource)
               .HasConversion<int>()
               .HasDefaultValue(BookingSource.Online);

        builder.Property(r => r.SpecialRequests)
               .HasMaxLength(1000);

        // Guest FK + navigation
        builder.HasOne(r => r.Guest)
               .WithMany(g => g.Reservations)
               .HasForeignKey(r => r.GuestId)
               .OnDelete(DeleteBehavior.Restrict);

        // Room has no navigation back on Reservation, so we configure the FK
        // explicitly without a navigation on the other side.
        builder.HasOne<Domain.Entities.Room.Room>()
               .WithMany()
               .HasForeignKey(r => r.RoomId)
               .OnDelete(DeleteBehavior.Restrict);

        // 1-to-many: Reservation -> Payments
        builder.HasMany(r => r.Payments)
               .WithOne(p => p.Reservation)
               .HasForeignKey(p => p.ReservationId)
               .OnDelete(DeleteBehavior.Cascade);

        // 1-to-0..1: Reservation -> Invoice (unique FK)
        builder.HasOne(r => r.Invoice)
               .WithOne(i => i.Reservation)
               .HasForeignKey<Invoice>(i => i.ReservationId)
               .OnDelete(DeleteBehavior.Cascade);

        // 1-to-0..1: Reservation -> Review (unique FK)
        builder.HasOne(r => r.Review)
               .WithOne(rv => rv.Reservation)
               .HasForeignKey<Review>(rv => rv.ReservationId)
               .OnDelete(DeleteBehavior.Cascade);

        // Booking calendar / availability lookups.
        builder.HasIndex(r => new { r.RoomId, r.CheckInDate, r.CheckOutDate });
        builder.HasIndex(r => r.GuestId);
        builder.HasIndex(r => r.Status);
    }
}
