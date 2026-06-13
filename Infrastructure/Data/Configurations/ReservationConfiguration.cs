using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");
        
        builder.HasKey(r => r.ReservationId);
        
        builder.Property(r => r.CheckInDate)
            .IsRequired();
        
        builder.Property(r => r.CheckOutDate)
            .IsRequired();
        
        builder.Property(r => r.NumberOfGuests)
            .IsRequired();
        
        builder.Property(r => r.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(r => r.SpecialRequests)
            .HasMaxLength(1000);
        
        builder.Property(r => r.GuestId)
            .IsRequired();
        
        builder.Property(r => r.RoomId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(r => r.Guest)
            .WithMany(g => g.Reservations)
            .HasForeignKey(r => r.GuestId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(r => r.Room)
            .WithMany(ro => ro.Reservations)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(r => r.Staff)
            .WithMany(s => s.Reservations)
            .HasForeignKey(r => r.StaffId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(r => r.Invoice)
            .WithOne(i => i.Reservation)
            .HasForeignKey<Invoice>(i => i.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(r => r.GuestServiceRequests)
            .WithOne(gsr => gsr.Reservation)
            .HasForeignKey(gsr => gsr.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
