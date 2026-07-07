using Domain.Entities.Room.Enums;
using Domain.Entities.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Room;

public class RoomConfiguration : BaseConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        base.Configure(builder);

        builder.ToTable("Rooms");

        builder.Property(r => r.RoomNumber)
               .IsRequired();

        builder.Property(r => r.FloorNumber)
               .IsRequired();

        builder.Property(r => r.PricePerNight)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(r => r.Status)
               .HasConversion<int>()
               .HasDefaultValue(RoomStatus.Available);

        builder.Property(r => r.Capacity)
               .IsRequired();

        builder.Property(r => r.Amenities)
               .HasMaxLength(1000);

        builder.HasOne(r => r.RoomType)
               .WithMany(rt => rt.Rooms)
               .HasForeignKey(r => r.TypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.RoomFeatureAssignments)
               .WithOne(a => a.Room)
               .HasForeignKey(a => a.RoomId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => r.RoomNumber)
               .IsUnique();

        builder.HasIndex(r => r.TypeId);
        builder.HasIndex(r => r.Status);
        builder.HasIndex(r => r.FloorNumber);
    }
}
