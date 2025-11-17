using Core.FlightContext.ReferenceData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="Destination"/> class.
/// </summary>
public class DestinationConfig : IEntityTypeConfiguration<Destination>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Destination"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.HasKey(d => d.IATAAirportCode);
            
        builder.HasOne(d => d.Country)
            .WithMany()
            .HasForeignKey(d => d.CountryId);
    }
}