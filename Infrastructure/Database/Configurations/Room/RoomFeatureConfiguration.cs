using Domain.Entities.Room.Enums;
using Domain.Entities.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Room;

public class RoomFeatureConfiguration : BaseConfiguration<RoomFeature>
{
    public override void Configure(EntityTypeBuilder<RoomFeature> builder)
    {
        base.Configure(builder);

        builder.ToTable("RoomFeatures");

        builder.Property(f => f.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.Description)
               .HasMaxLength(1000);

        builder.Property(f => f.Category)
               .HasConversion<int>();

        builder.Property(f => f.IsStandard)
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(f => f.AdditionalCost)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(f => f.IsAvailable)
               .IsRequired()
               .HasDefaultValue(true);

        builder.HasIndex(f => f.Name)
               .IsUnique();

        builder.HasIndex(f => f.Category);
    }
}
