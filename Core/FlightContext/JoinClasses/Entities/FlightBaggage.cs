using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.FlightContext.Flights.Entities;

namespace Core.FlightContext.JoinClasses.Entities;

/// <summary>
/// Represents the association between a flight and its baggage, including details
/// such as the flight, baggage, and baggage type.
/// </summary>
public class FlightBaggage
{
    /// <summary>
    /// Gets or sets the flight associated with the baggage.
    /// </summary>
    public BaseFlight Flight { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the flight.
    /// </summary>
    public Guid FlightId { get; set; }

    /// <summary>
    /// Gets the baggage associated with the flight.
    /// </summary>
    public Baggage Baggage { get; init; }

    /// <summary>
    /// Gets the unique identifier of the baggage.
    /// </summary>
    public Guid BaggageId { get; private set; }

    /// <summary>
    /// Gets the type of the baggage (e.g., local, transfer).
    /// </summary>
    public BaggageTypeEnum BaggageType { get; init; }

    public FlightBaggage(Guid flightId, Guid baggageId, BaggageTypeEnum baggageType)
    {
        FlightId = flightId;
        BaggageId = baggageId;
        BaggageType = baggageType;
    }
}