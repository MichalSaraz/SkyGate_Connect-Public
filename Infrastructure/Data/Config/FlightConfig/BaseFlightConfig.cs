using Core.FlightContext.Flights.Entities;
using Infrastructure.Data.ValueConversion.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="BaseFlight"/> class.
/// </summary>
public class BaseFlightConfig : IEntityTypeConfiguration<BaseFlight>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="BaseFlight"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<BaseFlight> builder)
    {
        builder.ToTable("Flights")
            .HasDiscriminator<string>("FlightType")
            .HasValue<Flight>("Scheduled")
            .HasValue<OtherFlight>("Other");
            
        builder.HasKey(bf => bf.Id);
            
        builder.HasOne(bf => bf.DestinationFrom)
            .WithMany(d => d.Departures)
            .HasForeignKey(bf => bf.DestinationFromId);
            
        builder.HasOne(bf => bf.DestinationTo)
            .WithMany(d => d.Arrivals)
            .HasForeignKey(bf => bf.DestinationToId);
            
        builder.HasOne(bf => bf.Airline)
            .WithMany()
            .HasForeignKey(bf => bf.AirlineId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Property(bf => bf.DepartureDateTime)
            .HasColumnType("timestamp without time zone");
            
        builder.Property(bf => bf.ArrivalDateTime)
            .HasColumnType("timestamp without time zone");
            
        builder.Property(bf => bf.UTCDepartureDateTime)
            .HasColumnType("timestamp with time zone")
            .HasConversion(typeof(DateTimeOffsetConverter));
            
        builder.Property(bf => bf.UTCArrivalDateTime)
            .HasColumnType("timestamp with time zone")
            .HasConversion(typeof(NullableDateTimeOffsetConverter));
    }
}