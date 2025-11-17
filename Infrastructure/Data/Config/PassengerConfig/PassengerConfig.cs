using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Passengers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig;

/// <summary>
/// Configures the entity type for the <see cref="Passenger"/> class.
/// </summary>
public class PassengerConfig : IEntityTypeConfiguration<Passenger>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Passenger"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasOne(p => p.FrequentFlyerCard)
            .WithOne(ff => ff.Passenger)
            .HasForeignKey<FrequentFlyer>(ff => ff.PassengerId);

        builder.HasOne(p => p.Infant)
            .WithOne(i => i.AssociatedAdultPassenger)
            .HasForeignKey<Infant>(i => i.AssociatedAdultPassengerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.PassengerCheckedBags)
            .WithOne(b => b.Passenger)
            .HasForeignKey(b => b.PassengerId);                       
    }
}