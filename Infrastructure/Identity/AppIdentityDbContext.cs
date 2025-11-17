using Core.Identity.Entities;
using Infrastructure.Data.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

/// <summary>
/// Represents the database context for identity-related entities, extending the functionality
/// of <see cref="IdentityDbContext{TUser}"/> with additional configurations for the <see cref="AppUser"/> entity.
/// </summary>
public class AppIdentityDbContext : IdentityDbContext<AppUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Configures the model for the identity database context, including custom property mappings
    /// for the <see cref="AppUser"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity models.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(entity =>
        {
            entity.Property(e => e.Role).HasEnumConversion();
        });
    }
}