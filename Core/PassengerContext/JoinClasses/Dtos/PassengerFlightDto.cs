namespace Core.PassengerContext.JoinClasses.Dtos;

/// <summary>
/// Represents the details of a passenger's flight, including identifiers, 
/// flight information, and boarding details.
/// </summary>
public class PassengerFlightDto
{
    /// <summary>
    /// Gets the unique identifier of the passenger or item.
    /// </summary>
    public Guid PassengerOrItemId { get; init; }

    /// <summary>
    /// Gets the unique identifier of the flight.
    /// </summary>
    public Guid FlightId { get; init; }

    /// <summary>
    /// Gets the flight number.
    /// </summary>
    public string FlightNumber { get; init; }

    /// <summary>
    /// Gets the departure location of the flight.
    /// </summary>
    public string DestinationFrom { get; init; }

    /// <summary>
    /// Gets the arrival location of the flight.
    /// </summary>
    public string DestinationTo { get; init; }

    /// <summary>
    /// Gets the departure date and time of the flight.
    /// </summary>
    public DateTime DepartureDateTime { get; init; }

    /// <summary>
    /// Gets the arrival date and time of the flight, if available.
    /// </summary>
    public DateTime? ArrivalDateTime { get; init; }

    /// <summary>
    /// Gets the flight class (e.g., Economy, Business, First Class).
    /// </summary>
    public string FlightClass { get; init; }

    /// <summary>
    /// Gets the boarding sequence number, if available.
    /// </summary>
    public int? BoardingSequenceNumber { get; init; }

    /// <summary>
    /// Gets the boarding zone of the passenger.
    /// </summary>
    public string BoardingZone { get; init; }

    /// <summary>
    /// Gets the acceptance status of the passenger for the flight.
    /// </summary>
    public string AcceptanceStatus { get; init; }

    /// <summary>
    /// Gets the reason why the passenger is not traveling, if applicable.
    /// </summary>
    public string NotTravellingReason { get; init; }
}