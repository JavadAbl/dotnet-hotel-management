using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");
        
        builder.HasKey(r => r.RoomId);
        
        builder.Property(r => r.RoomNumber)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.HasIndex(r => r.RoomNumber)
            .IsUnique();
        
        builder.Property(r => r.Floor)
            .IsRequired();
        
        builder.Property(r => r.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(r => r.RoomTypeId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(r => r.RoomType)
            .WithMany(rt => rt.Rooms)
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(r => r.Reservations)
            .WithOne(res => res.Room)
            .HasForeignKey(res => res.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(r => r.MaintenanceRequests)
            .WithOne(mr => mr.Room)
            .HasForeignKey(mr => mr.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
