using Core.PassengerContext.Comments.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.CommentConfig;

/// <summary>
/// Configures the entity type for the <see cref="PredefinedComment"/> class.
/// </summary>
public class PredefinedCommentConfig : IEntityTypeConfiguration<PredefinedComment>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="PredefinedComment"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<PredefinedComment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasEnumConversion();
    }
}