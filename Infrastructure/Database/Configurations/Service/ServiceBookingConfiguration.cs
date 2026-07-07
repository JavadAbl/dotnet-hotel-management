using Domain.Entities.Service.Enums;
using Domain.Entities.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Service;

public class ServiceBookingConfiguration : BaseConfiguration<ServiceBooking>
{
    public override void Configure(EntityTypeBuilder<ServiceBooking> builder)
    {
        base.Configure(builder);

        builder.ToTable("ServiceBookings");

        builder.Property(sb => sb.BookingDate)
               .IsRequired();

        builder.Property(sb => sb.ServiceDate)
               .IsRequired();

        builder.Property(sb => sb.ChargedAmount)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(sb => sb.Status)
               .HasConversion<int>()
               .HasDefaultValue(ServiceBookingStatus.Pending);

        builder.Property(sb => sb.Notes)
               .HasMaxLength(1000);

        // Only the Service navigation is declared on the entity, so we wire
        // that one through navigation; the remaining FKs (Reservation, Staff,
        // Room) are pure relationship columns without a back-navigation.
        builder.HasOne(sb => sb.Service)
               .WithMany(s => s.ServiceBookings)
               .HasForeignKey(sb => sb.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Booking.Reservation>()
               .WithMany()
               .HasForeignKey(sb => sb.ReservationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Staff.Staff>()
               .WithMany()
               .HasForeignKey(sb => sb.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Room.Room>()
               .WithMany()
               .HasForeignKey(sb => sb.RoomId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(sb => sb.ReservationId);
        builder.HasIndex(sb => sb.ServiceId);
        builder.HasIndex(sb => sb.StaffId);
        builder.HasIndex(sb => sb.RoomId);
        builder.HasIndex(sb => sb.ServiceDate);
        builder.HasIndex(sb => sb.Status);
    }
}
