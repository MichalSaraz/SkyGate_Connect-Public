using Core.PassengerContext.JoinClasses.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.JoinClassesConfig;

/// <summary>
/// Configures the entity type for the <see cref="PassengerFlight"/> class.
/// </summary>
public class PassengerFlightConfig : IEntityTypeConfiguration<PassengerFlight>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="PassengerFlight"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<PassengerFlight> builder)
    {
        builder.HasKey(pf => new { pf.PassengerOrItemId, pf.FlightId });

        builder.HasOne(pf => pf.PassengerOrItem)
            .WithMany(p => p.Flights)
            .HasForeignKey(pf => pf.PassengerOrItemId);

        builder.HasOne(pf => pf.Flight)
            .WithMany(bf => bf.ListOfBookedPassengers)
            .HasForeignKey(pf => pf.FlightId);

        builder.Property(pf => pf.BoardingZone)
            .HasNullableEnumConversion();

        builder.Property(pf => pf.FlightClass)
            .HasEnumConversion();

        builder.Property(pf => pf.AcceptanceStatus)
            .HasEnumConversion();

        builder.Property(pf => pf.NotTravellingReason)
            .HasNullableEnumConversion();
    }
}