using Domain.Entities.Staff.Enums;
using Domain.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Staff;

public class StaffConfiguration : BaseConfiguration<Staff>
{
    public override void Configure(EntityTypeBuilder<Staff> builder)
    {
        base.Configure(builder);

        builder.ToTable("Staffs");

        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.OperationalRole)
               .HasConversion<int>();

        builder.Property(s => s.Phone)
               .IsRequired()
               .HasMaxLength(32);

        builder.Property(s => s.ShiftSchedule)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.OperationalPermissions)
               .HasMaxLength(1000);

        // One-to-one: Staff -> User. The FK lives on User (StaffId), so the
        // relationship is configured on UserConfiguration. Here we only need
        // to acknowledge the navigation back to User.
        builder.HasOne(s => s.User)
               .WithOne(u => u.Staff)
               .HasForeignKey<User>(u => u.StaffId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => s.Phone);
        builder.HasIndex(s => s.OperationalRole);
    }
}
