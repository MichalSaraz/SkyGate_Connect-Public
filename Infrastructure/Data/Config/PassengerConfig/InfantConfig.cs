using Core.PassengerContext.Passengers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig;

/// <summary>
/// Configures the entity type for the <see cref="Infant"/> class.
/// </summary>
public class InfantConfig : IEntityTypeConfiguration<Infant>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Infant"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Infant> builder)
    {
        builder.HasOne(i => i.AssociatedAdultPassenger)
            .WithOne(p => p.Infant)
            .HasForeignKey<Passenger>(i => i.InfantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}