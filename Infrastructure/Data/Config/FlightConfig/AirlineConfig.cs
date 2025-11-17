using Core.FlightContext.ReferenceData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="Airline"/> class.
/// </summary>
public class AirlineConfig : IEntityTypeConfiguration<Airline>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Airline"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.HasKey(a => a.CarrierCode);
            
        builder.HasOne(a => a.Country)
            .WithMany()
            .HasForeignKey(a => a.CountryId);
            
        builder.HasMany(a => a.Fleet)
            .WithOne(a => a.Airline)
            .HasForeignKey(a => a.AirlineId);            
    }
}