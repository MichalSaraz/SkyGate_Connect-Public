using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Passengers.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.BookingConfig;

/// <summary>
/// Configures the entity type for the <see cref="FrequentFlyer"/> class.
/// </summary>
public class FrequentFlyerConfig : IEntityTypeConfiguration<FrequentFlyer>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="FrequentFlyer"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FrequentFlyer> builder)
    {
        builder.HasKey(ff => ff.Id);
            
        builder.HasOne(ff => ff.Passenger)
            .WithOne(p => p.FrequentFlyerCard)
            .HasForeignKey<Passenger>(p => p.FrequentFlyerCardId);
            
        builder.HasOne(ff => ff.Airline)
            .WithMany()
            .HasForeignKey(ff => ff.AirlineId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(ff => ff.FrequentFlyerNumber);
            
        builder.Property(ff => ff.TierLever)
            .HasEnumConversion();
    }
}