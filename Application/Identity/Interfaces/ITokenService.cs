using Core.Identity.Entities;

namespace Application.Identity.Interfaces;

/// <summary>
/// Interface defining the contract for a token service.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Creates a token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom to create the token.</param>
    /// <returns>The generated token as a string.</returns>
    string CreateToken(AppUser user);
}