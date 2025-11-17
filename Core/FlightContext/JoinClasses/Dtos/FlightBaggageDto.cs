using Core.FlightContext.Flights.Dtos;

namespace Core.FlightContext.JoinClasses.Dtos;

/// <summary>
/// Represents the association between a flight and baggage.
/// </summary>
public class FlightBaggageDto
{
    /// <summary>
    /// Gets the overview of the flight associated with the baggage.
    /// </summary>
    public FlightOverviewDto Flight { get; init; }

    /// <summary>
    /// Gets the type of the baggage (e.g., local, transfer).
    /// </summary>
    public string BaggageType { get; init; }
}