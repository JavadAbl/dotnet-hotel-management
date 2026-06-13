using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Data.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");
        
        builder.HasKey(g => g.GuestId);
        
        builder.Property(g => g.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(g => g.LastName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(g => g.Email)
            .IsRequired()
            .HasMaxLength(256);
        
        builder.HasIndex(g => g.Email)
            .IsUnique();
        
        builder.Property(g => g.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(g => g.IdProofNumber)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(g => g.Address)
            .HasMaxLength(500);
        
        builder.Property(g => g.DateOfBirth)
            .IsRequired();
        
        // Relationships
        builder.HasMany(g => g.Reservations)
            .WithOne(r => r.Guest)
            .HasForeignKey(r => r.GuestId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
