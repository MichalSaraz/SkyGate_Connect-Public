namespace Core.Identity.Dtos;

/// <summary>
/// Represents a user with details such as username, role, station, and authentication token.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// Gets or sets the station associated with the user.
    /// </summary>
    public string Station { get; set; }

    /// <summary>
    /// Gets or sets the authentication token of the user.
    /// </summary>
    public string Token { get; set; }
}