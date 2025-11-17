namespace Core.SeatContext.Enums;

/// <summary>
/// Represents the position of a seat within an aircraft.
/// </summary>
public enum SeatPositionEnum
{
    /// <summary>
    /// A jump seat, typically used by crew members.
    /// </summary>
    JumpSeat,

    /// <summary>
    /// A window seat, located next to the aircraft's window.
    /// </summary>
    Window,

    /// <summary>
    /// An aisle seat, located next to the aisle.
    /// </summary>
    Aisle,

    /// <summary>
    /// A middle seat, located between the window and aisle seats.
    /// </summary>
    Middle
}