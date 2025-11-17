using Core.PassengerContext.Bookings.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.BookingConfig;

/// <summary>
/// Configures the entity type for the <see cref="BookingReference"/> class.
/// </summary>
public class BookingReferenceConfig : IEntityTypeConfiguration<BookingReference>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="BookingReference"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<BookingReference> builder)
    {
        builder.HasKey(br => br.PNR);
            
        builder.HasMany(br => br.LinkedPassengers)
            .WithOne(pi => pi.PNR)
            .HasForeignKey(pi => pi.PNRId);
            
        builder.Property(br => br.FlightItinerary)
            .HasColumnName("FlightItinerary")
            .HasJsonConversion();
    }
}