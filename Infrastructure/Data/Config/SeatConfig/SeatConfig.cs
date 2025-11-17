using Core.SeatContext.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.SeatConfig;

/// <summary>
/// Configures the entity type for the <see cref="Seat"/> class.
/// </summary>
public class SeatConfig : IEntityTypeConfiguration<Seat>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Seat"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.Id);
            
        builder.HasOne(s => s.PassengerOrItem)
            .WithMany(p => p.AssignedSeats)
            .HasForeignKey(s => s.PassengerOrItemId);
            
        builder.HasOne(s => s.Flight)
            .WithMany(f => f.Seats)
            .HasForeignKey(s => s.FlightId);
            
        builder.Property(s => s.Letter)
            .HasEnumConversion();

        builder.Property(s => s.Position)
            .HasEnumConversion();
            
        builder.Property(s => s.SeatType)
            .HasEnumConversion();
            
        builder.Property(s => s.FlightClass)
            .HasEnumConversion();
            
        builder.Property(s => s.SeatStatus)
            .HasEnumConversion();
    }
}