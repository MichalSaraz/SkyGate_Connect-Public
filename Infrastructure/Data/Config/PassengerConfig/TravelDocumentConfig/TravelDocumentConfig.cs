using Core.PassengerContext.TravelDocuments.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.TravelDocumentConfig;

/// <summary>
/// Configures the entity type for the <see cref="TravelDocument"/> class.
/// </summary>
public class TravelDocumentConfig : IEntityTypeConfiguration<TravelDocument>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="TravelDocument"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<TravelDocument> builder)
    {
        builder.HasKey(ad => ad.Id);
            
        builder.HasOne(ad => ad.Passenger)
            .WithMany(p => p.TravelDocuments)
            .HasForeignKey(ad => ad.PassengerId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(ad => ad.Nationality)
            .WithMany()
            .HasForeignKey(ad => ad.NationalityId);
            
        builder.HasOne(ad => ad.CountryOfIssue)
            .WithMany()
            .HasForeignKey(ad => ad.CountryOfIssueId);
            
        builder.Property(ad => ad.DocumentType)
            .HasEnumConversion();
            
        builder.Property(ad => ad.Gender)
            .HasEnumConversion();
            
        builder.Property(ad => ad.DateOfBirth)
            .HasDateTimeConversion();
            
        builder.Property(ad => ad.DateOfIssue)
            .HasDateTimeConversion();
            
        builder.Property(ad => ad.ExpirationDate)
            .HasDateTimeConversion();
    }
}