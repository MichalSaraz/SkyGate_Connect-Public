namespace Core.SeatContext.Enums;

/// <summary>
/// Represents the seat preferences available for passengers.
/// </summary>
public enum SeatPreferenceEnum
{
    /// <summary>
    /// No specific seat preference.
    /// </summary>
    None,

    /// <summary>
    /// Preference for a window seat.
    /// </summary>
    Window,

    /// <summary>
    /// Preference for an aisle seat.
    /// </summary>
    Aisle,

    /// <summary>
    /// Preference for a middle seat.
    /// </summary>
    Middle,

    /// <summary>
    /// Preference for a seat near the emergency exit.
    /// </summary>
    Exit,

    /// <summary>
    /// Preference for a bulkhead seat.
    /// </summary>
    Bulkhead,

    /// <summary>
    /// Preference for a seat at the front of the aircraft.
    /// </summary>
    Front,
    
    /// <summary>
    /// Preference for a seat at the back of the aircraft.
    /// </summary>
    Back
}