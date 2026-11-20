using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomBooking.Api.Entities;

namespace RoomBooking.Api.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).IsRequired().HasMaxLength(30);
        builder.Property(r => r.Capacity).IsRequired();

        builder.HasIndex(r => r.Name).IsUnique();
    }
}