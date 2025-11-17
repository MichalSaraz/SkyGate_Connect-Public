using Newtonsoft.Json;

namespace Core.FlightContext.Flights.Dtos;

/// <summary>
/// Represents an overview of a flight, including its basic details such as 
/// identifiers, schedule, and destinations.
/// </summary>
public class FlightOverviewDto
{
    /// <summary>
    /// Gets the unique identifier of the flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the flight number.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string FlightNumber { get; init; }

    /// <summary>
    /// Gets the departure date and time of the flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public DateTime DepartureDateTime { get; init; }

    /// <summary>
    /// Gets the arrival date and time of the flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public DateTime ArrivalDateTime { get; init; }

    /// <summary>
    /// Gets the origin of the flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string DestinationFrom { get; init; }

    /// <summary>
    /// Gets the destination of the flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string DestinationTo { get; init; }
}