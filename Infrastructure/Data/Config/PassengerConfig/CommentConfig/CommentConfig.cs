using Core.PassengerContext.Comments.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PassengerConfig.CommentConfig;

/// <summary>
/// Configures the entity type for the <see cref="Comment"/> class.
/// </summary>
public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Comment"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
            
        builder.Property(c => c.CommentType)
            .HasEnumConversion();
            
        builder.HasOne(c => c.PassengerOrItem)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PassengerOrItemId);

        builder.Property(c => c.PredefinedCommentId)
            .HasNullableEnumConversion();

        builder.HasOne(c => c.PredefinedComment)
            .WithMany()
            .HasForeignKey(c => c.PredefinedCommentId);
    }
}