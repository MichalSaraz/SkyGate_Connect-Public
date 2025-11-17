namespace Core.SeatContext.Enums;

/// <summary>
/// Represents the status of a seat in the seating context.
/// </summary>
public enum SeatStatusEnum
{
    /// <summary>
    /// The seat is empty and available for use.
    /// </summary>
    Empty,

    /// <summary>
    /// The seat is currently occupied.
    /// </summary>
    Occupied,

    /// <summary>
    /// The seat is blocked and cannot be used unless unblocked.
    /// </summary>
    Blocked,

    /// <summary>
    /// The seat is inoperative and unavailable for use.
    /// </summary>
    Inop
}