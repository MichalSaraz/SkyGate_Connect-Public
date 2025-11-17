using Core.SeatContext.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.SeatConfig;

/// <summary>
/// Configures the entity type for the <see cref="SeatMap"/> class.
/// </summary>
public class SeatMapConfig : IEntityTypeConfiguration<SeatMap>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="SeatMap"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<SeatMap> builder)
    {
        builder.HasKey(sm => sm.Id);
            
        builder.Property(sm => sm.FlightClassesSpecification)
            .HasColumnName("FlightClassesSpecification")
            .HasJsonConversion();
    }
}