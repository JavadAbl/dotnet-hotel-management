using Domain.Entities.Service.Enums;
using Domain.Entities.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Service;

public class ServiceConfiguration : BaseConfiguration<Service>
{
    public override void Configure(EntityTypeBuilder<Service> builder)
    {
        base.Configure(builder);

        builder.ToTable("Services");

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Description)
               .HasMaxLength(1000);

        builder.Property(s => s.Price)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(s => s.Type)
               .HasConversion<int>();

        builder.HasIndex(s => s.Name)
               .IsUnique();

        builder.HasIndex(s => s.Type);

        builder.HasMany(s => s.ServiceBookings)
               .WithOne(sb => sb.Service)
               .HasForeignKey(sb => sb.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
