using System.ComponentModel.DataAnnotations;
using Core.Identity.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Identity.Entities;

/// <summary>
/// Represents an application user with additional properties for role and station.
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the role of the user in the system.
    /// </summary>
    public RoleEnum Role { get; set; }

    /// <summary>
    /// Gets or sets the station code associated with the user.
    /// The station code is limited to a maximum length of 3 characters.
    /// </summary>
    [StringLength(3)]
    public string Station { get; set; }
}