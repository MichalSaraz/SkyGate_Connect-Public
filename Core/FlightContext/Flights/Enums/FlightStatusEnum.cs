namespace Core.FlightContext.Flights.Enums;

/// <summary>
/// Represents the various statuses a flight can have during its handling lifecycle.
/// </summary>
public enum FlightStatusEnum
{
    /// <summary>
    /// Indicates that the flight is created but not yet open for check-in.
    /// </summary>
    NotOpen,

    /// <summary>
    /// Indicates that check-in is available for the flight.
    /// </summary>
    Open,

    /// <summary>
    /// Indicates that check-in is closed, but boarding may still be open.
    /// </summary>
    Closed,

    /// <summary>
    /// Indicates that the flight has been canceled.
    /// </summary>
    Suspended,

    /// <summary>
    /// Indicates that all passengers have boarded and the flight is ready for departure.
    /// </summary>
    Finalised
}