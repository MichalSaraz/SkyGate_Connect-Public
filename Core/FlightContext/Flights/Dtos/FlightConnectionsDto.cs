namespace Core.FlightContext.Flights.Dtos;

/// <summary>
/// Represents flight connections details.
/// </summary>
public class FlightConnectionsDto : FlightOverviewDto
{
    /// <summary>
    /// Gets or sets a number of flight connections.
    /// </summary>
    public int Count { get; set; }
}