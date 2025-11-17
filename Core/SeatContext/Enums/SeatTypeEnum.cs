namespace Core.SeatContext.Enums;

/// <summary>
/// Represents the types of seats available in the seating context.
/// </summary>
public enum SeatTypeEnum
{
    /// <summary>
    /// A standard seat, typically available for general passengers.
    /// </summary>
    Standard,

    /// <summary>
    /// A seat located near the emergency exit, offering extra legroom and requiring passengers to assist in emergencies.
    /// </summary>
    EmergencyExit,

    /// <summary>
    /// A bassinet seat, designed to accommodate passengers traveling with infants.
    /// </summary>
    BassinetSeat,

    /// <summary>
    /// A jump seat, typically used by crew members.
    /// </summary>
    JumpSeat
}