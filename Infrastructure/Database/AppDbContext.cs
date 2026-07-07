using Domain.Entities;
using Domain.Entities.Booking;
using Domain.Entities.Room;
using Domain.Entities.Service;
using Domain.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<RoomFeature> RoomFeatures { get; set; }
    public DbSet<RoomFeatureAssignment> RoomFeatureAssignments { get; set; }

    public DbSet<RoomCleaning> RoomCleanings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceBooking> ServiceBookings { get; set; }

    public DbSet<Staff> Staffs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // All IEntityTypeConfiguration<T> classes in this assembly
        // (under Infrastructure.Database.Configurations) are picked up
        // automatically and applied here.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Automatically maintain <see cref="BaseEntity.UpdatedAt"/> on save.
    /// </summary>
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetAuditTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        SetAuditTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void SetAuditTimestamps()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            var now = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = now;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = now;
                    // Prevent the CreatedAt/CreatedBy fields from being
                    // silently overwritten on update.
                    entry.Property(nameof(BaseEntity.CreatedAt)).IsModified = false;
                    entry.Property(nameof(BaseEntity.CreatedBy)).IsModified = false;
                    break;
            }
        }
    }
}