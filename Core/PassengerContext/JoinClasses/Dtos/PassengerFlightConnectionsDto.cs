namespace Core.PassengerContext.JoinClasses.Dtos;

/// <summary>
/// Represents a passenger's flight connections, including personal details,
/// flight class, seat number, and a list of connected flights.
/// </summary>
public class PassengerFlightConnectionsDto
{
    /// <summary>
    /// Gets the first name of the passenger.
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Gets the last name of the passenger.
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Gets the gender of the passenger.
    /// </summary>
    public string Gender { get; init; }

    /// <summary>
    /// Gets the number of checked bags for the passenger.
    /// </summary>
    public int NumberOfCheckedBags { get; init; }

    /// <summary>
    /// Gets the flight class of the passenger (e.g., Economy, Business, First Class).
    /// </summary>
    public string FlightClass { get; init; }

    /// <summary>
    /// Gets the seat number assigned to the passenger.
    /// </summary>
    public string SeatNumber { get; init; }

    /// <summary>
    /// Gets the list of flight connections associated with the passenger.
    /// </summary>
    public List<PassengerFlightDto> FlightConnections { get; init; }
}