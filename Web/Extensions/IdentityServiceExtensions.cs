using System.Text;
using Core.Identity.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Web.Extensions;

/// <summary>
/// Provides extension methods for configuring identity and authentication services in the application.
/// </summary>
public static class IdentityServiceExtensions
{
    /// <summary>
    /// Configures identity and authentication services, including database context, identity options, 
    /// JWT authentication, and authorization.
    /// </summary>
    /// <param name="services">The service collection to which the services will be added.</param>
    /// <param name="config">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppIdentityDbContext>(options =>
        {
            options.UseNpgsql(config.GetConnectionString("IdentityConnection"));
        });

        services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["Token:Key"] ?? string.Empty)),
                    ValidIssuer = config["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });

        services.AddAuthorization();

        return services;
    }
}