namespace Core.PassengerContext.Passengers.Enums;

/// <summary>
/// Represents the acceptance status of a passenger during the check-in process.
/// </summary>
public enum AcceptanceStatusEnum
{
    /// <summary>
    /// Indicates that the passenger has been accepted.
    /// </summary>
    Accepted,

    /// <summary>
    /// Indicates that the passenger has not been accepted.
    /// </summary>
    NotAccepted,

    /// <summary>
    /// Indicates that the passenger is on standby.
    /// </summary>
    Standby,

    /// <summary>
    /// Indicates that the passenger has boarded the flight.
    /// </summary>
    Boarded,

    /// <summary>
    /// Indicates that the passenger is not traveling.
    /// </summary>
    NotTravelling
}