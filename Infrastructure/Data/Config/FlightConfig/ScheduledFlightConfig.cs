using Core.FlightContext.Flights.Entities;
using Infrastructure.Data.ValueConversion;
using Infrastructure.Data.ValueConversion.Comparers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="ScheduledFlight"/> class.
/// </summary>
public class ScheduledFlightConfig : IEntityTypeConfiguration<ScheduledFlight>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="ScheduledFlight"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<ScheduledFlight> builder)
    {
        builder.HasKey(sf => sf.FlightNumber);

        builder.HasOne(sf => sf.DestinationFrom)
            .WithMany()
            .HasForeignKey(sf => sf.DestinationFromId);

        builder.HasOne(sf => sf.DestinationTo)
            .WithMany()
            .HasForeignKey(sf => sf.DestinationToId);

        builder.Property(sf => sf.DepartureTimesInLocalTime)
            .HasJsonConversion()
            .HasColumnType("jsonb")
            .HasConversion(
                typeof(TimeSpanKeyValuePairJsonConverter),
                typeof(ListValueComparer<KeyValuePair<DayOfWeek, TimeSpan>>));

        builder.Property(sf => sf.ArrivalTimesInLocalTime)
            .HasJsonConversion()
            .HasColumnType("jsonb")
            .HasConversion(
                typeof(TimeSpanKeyValuePairJsonConverter),
                typeof(ListValueComparer<KeyValuePair<DayOfWeek, TimeSpan>>));

        builder.Property(sf => sf.FlightDuration)
            .HasJsonConversion()
            .HasColumnType("jsonb")
            .HasConversion(
                typeof(TimeSpanKeyValuePairJsonConverter),
                typeof(ListValueComparer<KeyValuePair<DayOfWeek, TimeSpan>>));

        builder.Property(sf => sf.DepartureTimesInUTCTime)
            .HasJsonConversion()
            .HasColumnType("jsonb")
            .HasConversion(
                typeof(DateTimeOffsetKeyValuePairJsonConverter),
                typeof(DateTimeOffsetKeyValuePairListComparer));

        builder.Property(sf => sf.ArrivalTimesInUTCTime)
            .HasJsonConversion()
            .HasColumnType("jsonb")
            .HasConversion(
                typeof(DateTimeOffsetKeyValuePairJsonConverter),
                typeof(DateTimeOffsetKeyValuePairListComparer));
    }
}