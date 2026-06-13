using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");
        
        builder.HasKey(rt => rt.RoomTypeId);
        
        builder.Property(rt => rt.TypeName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(rt => rt.BasePrice)
            .IsRequired()
            .HasPrecision(18, 2);
        
        builder.Property(rt => rt.MaxOccupancy)
            .IsRequired();
        
        builder.Property(rt => rt.BedType)
            .HasMaxLength(50);
        
        builder.Property(rt => rt.Amenities)
            .HasMaxLength(500);
        
        // Relationships
        builder.HasMany(rt => rt.Rooms)
            .WithOne(r => r.RoomType)
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
