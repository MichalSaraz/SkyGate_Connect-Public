using Core.FlightContext.Flights.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="OtherFlight"/> class.
/// </summary>
public class OtherFlightConfig : IEntityTypeConfiguration<OtherFlight>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="OtherFlight"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<OtherFlight> builder)
    {
        builder.Property(of => of.FlightNumber)
            .HasColumnName("OtherFlightFltNumber");
    }
}