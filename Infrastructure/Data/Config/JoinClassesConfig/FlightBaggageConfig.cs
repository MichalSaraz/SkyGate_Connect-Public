using Core.FlightContext.JoinClasses.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.JoinClassesConfig;

/// <summary>
/// Configures the entity type for the <see cref="FlightBaggage"/> class.
/// </summary>
public class FlightBaggageConfig : IEntityTypeConfiguration<FlightBaggage>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="FlightBaggage"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FlightBaggage> builder)
    {
        builder.HasKey(fb => new { fb.FlightId, fb.BaggageId });

        builder.HasOne(fb => fb.Flight)
            .WithMany(bf => bf.ListOfCheckedBaggage)
            .HasForeignKey(fb => fb.FlightId);

        builder.HasOne(fb => fb.Baggage)
            .WithMany(b => b.Flights)
            .HasForeignKey(fb => fb.BaggageId);
            
        builder.Property(fb => fb.BaggageType)
            .HasEnumConversion();
    }
}