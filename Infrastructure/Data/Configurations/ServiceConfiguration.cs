using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");
        
        builder.HasKey(s => s.ServiceId);
        
        builder.Property(s => s.ServiceName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.UnitPrice)
            .IsRequired()
            .HasPrecision(18, 2);
        
        // Relationships
        builder.HasMany(s => s.GuestServiceRequests)
            .WithOne(gsr => gsr.Service)
            .HasForeignKey(gsr => gsr.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
