using Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Booking;

public class ReviewConfiguration : BaseConfiguration<Review>
{
    public override void Configure(EntityTypeBuilder<Review> builder)
    {
        base.Configure(builder);

        builder.ToTable("Reviews");

        builder.Property(r => r.Rating)
               .IsRequired();

        // Rating is 1-5 by convention; enforce at the DB level.
        builder.HasCheckConstraint("CK_Reviews_Rating_Range", "\"Rating\" BETWEEN 1 AND 5");

        builder.Property(r => r.Comments)
               .HasMaxLength(2000);

        builder.Property(r => r.ReviewDate)
               .IsRequired();

        builder.HasOne(r => r.Guest)
               .WithMany(g => g.Reviews)
               .HasForeignKey(r => r.GuestId)
               .OnDelete(DeleteBehavior.Restrict);

        // The Reservation -> Review (1-to-0..1) relationship is set up in
        // ReservationConfiguration. We just need the unique FK index here.
        builder.HasIndex(r => r.ReservationId)
               .IsUnique();

        builder.HasIndex(r => r.GuestId);
        builder.HasIndex(r => r.Rating);
    }
}
