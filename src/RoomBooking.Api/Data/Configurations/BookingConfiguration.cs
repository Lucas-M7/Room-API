using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomBooking.Api.Entities;

namespace RoomBooking.Api.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.ReservedBy).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Status).HasConversion<string>().HasMaxLength(20);
        builder.Property(b => b.CancellationReason).HasMaxLength(200);

        builder.HasOne(b => b.Room)             // a booking has ONE room
            .WithMany(r => r.Bookings)          // and a room has MANY bookings
            .HasForeignKey(b => b.RoomId)       // FK that connect
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(b => new { b.RoomId, b.StartUtc, b.EndUtc });
    }
}