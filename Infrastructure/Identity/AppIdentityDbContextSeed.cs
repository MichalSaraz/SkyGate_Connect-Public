using Core.Identity.Entities;
using Core.Identity.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

/// <summary>
/// Provides methods for seeding the identity database with default users.
/// </summary>
public class AppIdentityDbContextSeed
{
    /// <summary>
    /// Seeds the identity database with default users if no users exist.
    /// </summary>
    /// <param name="userManager">The <see cref="UserManager{TUser}"/> instance used to manage users.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                UserName = "Admin",
                Role = RoleEnum.Admin,
                Station = "PRG"
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}