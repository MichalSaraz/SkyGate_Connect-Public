using Core.FlightContext.JoinClasses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.JoinClassesConfig;

/// <summary>
/// Configures the entity type for the <see cref="FlightComment"/> class.
/// </summary>
public class FlightCommentConfig : IEntityTypeConfiguration<FlightComment>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="FlightComment"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FlightComment> builder)
    {
        builder.HasKey(fc => new { fc.CommentId, fc.FlightId });

        builder.HasOne(fc => fc.Comment)
            .WithMany(c => c.LinkedToFlights)
            .HasForeignKey(fc => fc.CommentId);

        builder.HasOne(fc => fc.Flight)
            .WithMany(f => f.Comments)
            .HasForeignKey(fc => fc.FlightId);
    }
}