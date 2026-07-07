using Domain.Entities.Staff.Enums;
using Domain.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Staff;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");

        builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(64);

        builder.Property(u => u.PasswordHash)
               .IsRequired()
               .HasMaxLength(512);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(256);

        builder.Property(u => u.SystemRole)
               .HasConversion<int>()
               .HasDefaultValue(SystemRole.Staff);

        builder.Property(u => u.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(u => u.LastLogin);

        // The Staff -> User relationship (1-to-1) is declared on
        // StaffConfiguration. We just enforce the unique FK side here.
        builder.HasIndex(u => u.StaffId)
               .IsUnique();

        builder.HasIndex(u => u.Username)
               .IsUnique();

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.HasIndex(u => u.IsActive);
    }
}
