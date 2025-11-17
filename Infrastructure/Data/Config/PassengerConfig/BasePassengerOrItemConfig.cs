using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Passengers.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig;

/// <summary>
/// Configures the entity type for the <see cref="BasePassengerOrItem"/> class.
/// </summary>
public class BasePassengerOrItemConfig : IEntityTypeConfiguration<BasePassengerOrItem>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="BasePassengerOrItem"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<BasePassengerOrItem> builder)
    {
        builder.ToTable("Passengers")
            .HasDiscriminator<string>("PassengerOrItemType")
            .HasValue<Passenger>("Passenger")
            .HasValue<Infant>("Infant")
            .HasValue<CabinBaggageRequiringSeat>("CBBG")
            .HasValue<ExtraSeat>("EXST");

        builder.HasKey(bpoi => bpoi.Id);

        builder.Property(bpoi => bpoi.Gender)
            .HasEnumConversion();

        builder.HasOne(bpoi => bpoi.BookingDetails)
            .WithOne(pbd => pbd.PassengerOrItem)
            .HasForeignKey<PassengerBookingDetails>(pbd => pbd.PassengerOrItemId);            

        builder.HasMany(bpoi => bpoi.TravelDocuments)
            .WithOne(td => td.Passenger)
            .HasForeignKey(td => td.PassengerId);

        builder.HasMany(bpoi => bpoi.Comments)
            .WithOne(c => c.PassengerOrItem)
            .HasForeignKey(c => c.PassengerOrItemId);

        builder.HasMany(bpoi => bpoi.AssignedSeats)
            .WithOne(s => s.PassengerOrItem)
            .HasForeignKey(s => s.PassengerOrItemId);
    }
}