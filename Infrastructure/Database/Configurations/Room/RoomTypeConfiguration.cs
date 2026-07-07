using Domain.Entities.Room.Enums;
using Domain.Entities.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Room;

public class RoomTypeConfiguration : BaseConfiguration<RoomType>
{
    public override void Configure(EntityTypeBuilder<RoomType> builder)
    {
        base.Configure(builder);

        builder.ToTable("RoomTypes");

        builder.Property(rt => rt.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(rt => rt.BasePrice)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(rt => rt.Description)
               .HasMaxLength(1000);

        builder.Property(rt => rt.MaxOccupancy)
               .IsRequired();

        builder.Property(rt => rt.StandardAmenities)
               .HasMaxLength(1000);

        builder.HasIndex(rt => rt.Name)
               .IsUnique();

        builder.HasMany(rt => rt.Rooms)
               .WithOne(r => r.RoomType)
               .HasForeignKey(r => r.TypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
