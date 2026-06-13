using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff");
        
        builder.HasKey(s => s.StaffId);
        
        builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.Role)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(256);
        
        builder.HasIndex(s => s.Email)
            .IsUnique();
        
        builder.Property(s => s.DepartmentId)
            .IsRequired();
        
        // Relationships
        builder.HasOne(s => s.Department)
            .WithMany(d => d.StaffMembers)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(s => s.Reservations)
            .WithOne(r => r.Staff)
            .HasForeignKey(r => r.StaffId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(s => s.MaintenanceRequests)
            .WithOne(mr => mr.Staff)
            .HasForeignKey(mr => mr.StaffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
