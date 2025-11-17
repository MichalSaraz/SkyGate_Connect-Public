using Core.FlightContext.ReferenceData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.FlightConfig;

/// <summary>
/// Configures the entity type for the <see cref="Aircraft"/> class.
/// </summary>
public class AircraftConfig : IEntityTypeConfiguration<Aircraft>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Aircraft"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        builder.HasKey(a => a.RegistrationCode);
            
        builder.HasOne(a => a.Country)
            .WithMany()
            .HasForeignKey(a => a.CountryId);
            
        builder.HasOne(a => a.AircraftType)
            .WithMany()
            .HasForeignKey(a => a.AircraftTypeId);
            
        builder.HasOne(a => a.Airline)
            .WithMany(a => a.Fleet)
            .HasForeignKey(a => a.AirlineId);
            
        builder.HasOne(a => a.SeatMap)
            .WithMany()
            .HasForeignKey(a => a.SeatMapId);
    }
}