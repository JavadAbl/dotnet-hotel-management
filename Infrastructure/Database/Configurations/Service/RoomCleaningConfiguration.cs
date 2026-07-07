using Domain.Entities.Service.Enums;
using Domain.Entities.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Service;

public class RoomCleaningConfiguration : BaseConfiguration<RoomCleaning>
{
    public override void Configure(EntityTypeBuilder<RoomCleaning> builder)
    {
        base.Configure(builder);

        builder.ToTable("RoomCleanings");

        builder.Property(rc => rc.ScheduledDateTime)
               .IsRequired();

        builder.Property(rc => rc.Status)
               .HasConversion<int>()
               .HasDefaultValue(CleaningStatus.Scheduled);

        builder.Property(rc => rc.CleaningType)
               .HasConversion<int>();

        builder.Property(rc => rc.Notes)
               .HasMaxLength(1000);

        builder.Property(rc => rc.QualityRating);

        builder.HasCheckConstraint(
            "CK_RoomCleanings_QualityRating_Range",
            "\"QualityRating\" IS NULL OR (\"QualityRating\" BETWEEN 1 AND 5)");

        builder.Property(rc => rc.DurationMinutes);

        builder.HasCheckConstraint(
            "CK_RoomCleanings_DurationMinutes_Positive",
            "\"DurationMinutes\" IS NULL OR (\"DurationMinutes\" > 0)");

        // RoomCleaning has no navigation properties — declare FKs purely.
        builder.HasOne<Domain.Entities.Room.Room>()
               .WithMany()
               .HasForeignKey(rc => rc.RoomId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Domain.Entities.Staff.Staff>()
               .WithMany()
               .HasForeignKey(rc => rc.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(rc => new { rc.RoomId, rc.ScheduledDateTime });
        builder.HasIndex(rc => rc.StaffId);
        builder.HasIndex(rc => rc.Status);
        builder.HasIndex(rc => rc.CleaningType);
    }
}
