using Core.FlightContext.JoinClasses.Dtos;

namespace Core.BaggageContext.Dtos;

/// <summary>
/// Represents detailed information about a piece of baggage, 
/// including associated flights.
/// </summary>
public class BaggageDetailsDto : BaggageOverviewDto
{
    /// <summary>
    /// Gets a list of flights associated with the baggage.
    /// </summary>
    public List<FlightBaggageDto> Flights { get; init; } = new();
}