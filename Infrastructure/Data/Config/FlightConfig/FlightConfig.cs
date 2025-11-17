using Core.FlightContext.Flights.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="Flight"/> class.
/// </summary>
public class FlightConfig : IEntityTypeConfiguration<Flight>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Flight"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Flight> builder)
    {  
        builder.HasOne(f => f.ScheduledFlight)
            .WithMany()
            .HasForeignKey(f => f.ScheduledFlightId);
            
        builder.HasOne(f => f.Aircraft)
            .WithMany(a => a.Flights)
            .HasForeignKey(f => f.AircraftId);

        builder.Property(f => f.BoardingStatus)
            .HasEnumConversion();

        builder.Property(f => f.FlightStatus)
            .HasEnumConversion();

        builder.HasMany(f => f.Seats)
            .WithOne(s => s.Flight)
            .HasForeignKey(s => s.FlightId);
    }
}