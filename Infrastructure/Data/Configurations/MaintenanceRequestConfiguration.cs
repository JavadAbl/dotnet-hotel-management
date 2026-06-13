using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
    {
        builder.ToTable("MaintenanceRequests");
        
        builder.HasKey(mr => mr.MaintenanceId);
        
        builder.Property(mr => mr.Description)
            .IsRequired()
            .HasMaxLength(1000);
        
        builder.Property(mr => mr.Priority)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(mr => mr.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(mr => mr.ReportedDate)
            .IsRequired();
        
        builder.Property(mr => mr.RoomId)
            .IsRequired();
        
        builder.Property(mr => mr.StaffId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(mr => mr.Room)
            .WithMany(r => r.MaintenanceRequests)
            .HasForeignKey(mr => mr.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(mr => mr.Staff)
            .WithMany(s => s.MaintenanceRequests)
            .HasForeignKey(mr => mr.StaffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
