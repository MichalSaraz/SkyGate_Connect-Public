namespace Core.Identity.Enums;

/// <summary>
/// Represents the roles available in the system.
/// </summary>
public enum RoleEnum
{
    /// <summary>
    /// Role for administrators with full access to the system.
    /// </summary>
    Admin,

    /// <summary>
    /// Role for passenger service staff responsible for handling passenger-related tasks.
    /// </summary>
    PassengerService,

    /// <summary>
    /// Role for load control staff managing weight and balance of aircraft.
    /// </summary>
    LoadControl
}