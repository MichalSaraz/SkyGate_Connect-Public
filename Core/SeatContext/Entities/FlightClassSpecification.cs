using Core.SeatContext.Enums;

namespace Core.SeatContext.Entities;

/// <summary>
/// Represents the specification for a flight class, including available seat positions and other related details.
/// </summary>
public abstract class FlightClassSpecification
{
    /// <summary>
    /// Gets the flight class associated with this specification.
    /// </summary>
    public FlightClassEnum FlightClass { get; }

    /// <summary>
    /// Gets the list of seat positions available in this flight class.
    /// </summary>
    public List<string> SeatPositionsAvailable { get; }

    /// <summary>
    /// Gets the list of window seat positions in this flight class.
    /// </summary>
    public List<string> WindowPositions { get; }

    /// <summary>
    /// Gets the list of aisle seat positions in this flight class.
    /// </summary>
    public List<string> AislePositions { get; }

    /// <summary>
    /// Gets the list of middle seat positions in this flight class.
    /// </summary>
    public List<string> MiddlePositions { get; }

    /// <summary>
    /// Gets the list of seats located in the exit row for this flight class.
    /// </summary>
    public List<string> ExitRowSeats { get; }

    /// <summary>
    /// Gets the list of bassinet seats available in this flight class.
    /// </summary>
    public List<string> BassinetSeats { get; }

    /// <summary>
    /// Gets the list of seat positions that do not exist in this flight class.
    /// </summary>
    public List<string> NotExistingSeats { get; }

    /// <summary>
    /// Gets the range of rows available in this flight class.
    /// </summary>
    public List<int> RowRange { get; }
}