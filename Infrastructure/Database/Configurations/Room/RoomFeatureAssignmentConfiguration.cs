using Domain.Entities.Room.Enums;
using Domain.Entities.Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Room;

public class RoomFeatureAssignmentConfiguration : BaseConfiguration<RoomFeatureAssignment>
{
    public override void Configure(EntityTypeBuilder<RoomFeatureAssignment> builder)
    {
        base.Configure(builder);

        builder.ToTable("RoomFeatureAssignments");

        builder.Property(a => a.AddedDate)
               .IsRequired();

        builder.Property(a => a.Status)
               .HasConversion<int>()
               .HasDefaultValue(AssignmentStatus.Active);

        builder.Property(a => a.Notes)
               .HasMaxLength(1000);

        builder.HasOne(a => a.Room)
               .WithMany(r => r.RoomFeatureAssignments)
               .HasForeignKey(a => a.RoomId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.RoomFeature)
               .WithMany(f => f.RoomFeatureAssignments)
               .HasForeignKey(a => a.FeatureId)
               .OnDelete(DeleteBehavior.Restrict);

        // A specific feature can only be assigned once to a given room.
        builder.HasIndex(a => new { a.RoomId, a.FeatureId })
               .IsUnique();

        builder.HasIndex(a => a.Status);
    }
}
