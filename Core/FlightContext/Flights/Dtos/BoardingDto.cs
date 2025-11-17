namespace Core.FlightContext.Flights.Dtos;

/// <summary>
/// Represents the boarding details of a flight, including boarding status,
/// passenger counts, and zone-specific information.
/// </summary>
public class BoardingDto
{
    /// <summary>
    /// Gets the current boarding status of the flight.
    /// </summary>
    public string BoardingStatus { get; init; }

    /// <summary>
    /// Gets the number of comments related to the boarding gate.
    /// </summary>
    public int NumberOfGateComments { get; init; }

    /// <summary>
    /// Gets the number of passengers with special service requests.
    /// </summary>
    public int NumberOfPassengersWithSpecialServiceRequests { get; init; }

    /// <summary>
    /// Gets the number of passengers with priority boarding.
    /// </summary>
    public int NumberOfPassengersWithPriorityBoarding { get; init; }

    /// <summary>
    /// Gets the total number of passengers who have boarded.
    /// </summary>
    public int BoardedPassengers { get; init; }

    /// <summary>
    /// Gets the number of passengers who have not boarded, categorized by zones.
    /// </summary>
    public Dictionary<char, int> NotBoardedPassengersByZones { get; init; }
}