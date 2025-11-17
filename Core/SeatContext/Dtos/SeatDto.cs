namespace Core.SeatContext.Dtos;

/// <summary>
/// Represents a seat on a flight, including its details such as seat number,
/// class, status, type, and associated passenger or item information.
/// </summary>
public class SeatDto
{
    /// <summary>
    /// Gets the unique identifier of the seat.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the unique identifier of the flight associated with the seat.
    /// </summary>
    public Guid FlightId { get; init; }

    /// <summary>
    /// Gets the flight number associated with the seat.
    /// </summary>
    public string FlightNumber { get; init; }

    /// <summary>
    /// Gets the seat number.
    /// </summary>
    public string SeatNumber { get; init; }

    /// <summary>
    /// Gets the class of the flight (e.g., Economy, Business, First Class).
    /// </summary>
    public string FlightClass { get; init; }

    /// <summary>
    /// Gets the status of the seat (e.g., Available, Reserved, Occupied).
    /// </summary>
    public string SeatStatus { get; init; }

    /// <summary>
    /// Gets the type of the seat (e.g., Window, Aisle, Middle).
    /// </summary>
    public string SeatType { get; init; }

    /// <summary>
    /// Gets the unique identifier of the passenger or item associated with the seat, if any.
    /// </summary>
    public Guid? PassengerOrItemId { get; init; }

    /// <summary>
    /// Gets the first name of the passenger associated with the seat.
    /// </summary>
    public string PassengerFirstName { get; init; }

    /// <summary>
    /// Gets the last name of the passenger associated with the seat.
    /// </summary>
    public string PassengerLastName { get; init; }
}