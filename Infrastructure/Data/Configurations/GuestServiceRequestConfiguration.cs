using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class GuestServiceRequestConfiguration : IEntityTypeConfiguration<GuestServiceRequest>
{
    public void Configure(EntityTypeBuilder<GuestServiceRequest> builder)
    {
        builder.ToTable("GuestServiceRequests");
        
        builder.HasKey(gsr => gsr.RequestId);
        
        builder.Property(gsr => gsr.Quantity)
            .IsRequired();
        
        builder.Property(gsr => gsr.RequestDate)
            .IsRequired();
        
        builder.Property(gsr => gsr.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(gsr => gsr.ReservationId)
            .IsRequired();
        
        builder.Property(gsr => gsr.ServiceId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(gsr => gsr.Reservation)
            .WithMany(r => r.GuestServiceRequests)
            .HasForeignKey(gsr => gsr.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(gsr => gsr.Service)
            .WithMany(s => s.GuestServiceRequests)
            .HasForeignKey(gsr => gsr.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
