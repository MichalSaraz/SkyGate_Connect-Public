using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Passengers.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.BookingConfig;

/// <summary>
/// Configures the entity type for the <see cref="PassengerBookingDetails"/> class.
/// </summary>
public class PassengerBookingDetailsConfig : IEntityTypeConfiguration<PassengerBookingDetails>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="PassengerBookingDetails"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<PassengerBookingDetails> builder)
    {            
        builder.HasKey(pbd => pbd.Id);
        builder.Property(pbd => pbd.Gender)
            .HasEnumConversion();    
            
        builder.HasOne(pbd => pbd.PNR)
            .WithMany(br => br.LinkedPassengers)
            .HasForeignKey(pi => pi.PNRId);

        builder.HasOne(pbd => pbd.PassengerOrItem)
            .WithOne(p => p.BookingDetails)
            .HasForeignKey<BasePassengerOrItem>(p => p.BookingDetailsId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(pbd => pbd.AssociatedPassengerBookingDetails)
            .WithOne()
            .HasForeignKey<PassengerBookingDetails>(p => p.AssociatedPassengerBookingDetailsId)
            .OnDelete(DeleteBehavior.SetNull);
            
        builder.Property(pbd => pbd.BookedClass)
            .HasColumnName("BookedClass")
            .HasJsonConversion();
             
        builder.Property(pbd => pbd.ReservedSeats)
            .HasColumnName("ReservedSeats")
            .HasJsonConversion();
             
        builder.Property(pbd => pbd.BookedSSR)
            .HasColumnName("BookedSSR")
            .HasJsonConversion();
    }
}