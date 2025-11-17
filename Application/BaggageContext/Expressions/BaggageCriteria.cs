using System.Linq.Expressions;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;

namespace Application.BaggageContext.Expressions;

/// <summary>
/// Provides reusable LINQ expressions to query <see cref="Baggage"/> entities.
/// </summary>
public static class BaggageCriteria
{
    /// <summary>
    /// Returns an expression that matches all baggage associated with the specified flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight to filter baggage by.</param>
    /// <returns>
    /// An expression that evaluates to <c>true</c> for baggage that have at least one flight entry
    /// with the provided <paramref name="flightId"/>.
    /// </returns>
    public static Expression<Func<Baggage, bool>> GetAllBagsForFlight(Guid flightId)
    {
        return b => b.Flights.Any(fb => fb.FlightId == flightId);
    }

    /// <summary>
    /// Returns an expression that matches baggage of a specific <see cref="BaggageTypeEnum"/> for a flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight to filter baggage by.</param>
    /// <param name="baggageType">The baggage type to match (e.g. local, transfer).</param>
    /// <returns>
    /// An expression that evaluates to <c>true</c> for baggage that are associated with the given flight
    /// and have the requested <paramref name="baggageType"/>.
    /// </returns>
    public static Expression<Func<Baggage, bool>> GetBagsByBaggageType(Guid flightId, BaggageTypeEnum baggageType)
    {
        return b => b.Flights.Any(fb => fb.FlightId == flightId && fb.BaggageType == baggageType);
    }

    /// <summary>
    /// Returns an expression that matches baggage considered inactive for the specified flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight to filter baggage by.</param>
    /// <returns>
    /// An expression that evaluates to <c>true</c> for baggage that are associated with the given flight
    /// but do not have a valid baggage tag number.
    /// </returns>
    public static Expression<Func<Baggage, bool>> GetInactiveBags(Guid flightId)
    {
        return b => b.Flights.Any(fb => fb.FlightId == flightId) && 
                    (b.BaggageTag == null || string.IsNullOrEmpty(b.BaggageTag.TagNumber));
    }

    /// <summary>
    /// Returns an expression that matches baggage having a specific special bag type for the flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight to filter baggage by.</param>
    /// <param name="specialBagType">The special bag type to match.</param>
    /// <returns>
    /// An expression that evaluates to <c>true</c> for baggage associated with the given flight and
    /// having a non-null <c>SpecialBag</c> with the specified type.
    /// </returns>
    public static Expression<Func<Baggage, bool>> GetBagsBySpecialBagType(Guid flightId, SpecialBagEnum specialBagType)
    {
        return b => b.Flights.Any(fb => fb.FlightId == flightId) && 
                    b.SpecialBag != null &&
                    b.SpecialBag.SpecialBagType == specialBagType;
    }

    /// <summary>
    /// Returns an expression that matches baggage on the specified flight that have onward connections
    /// (i.e. they are also booked on a later flight with a later departure time).
    /// </summary>
    /// <param name="flightId">The identifier of the reference flight.</param>
    /// <returns>
    /// An expression that evaluates to <c>true</c> for baggage which are associated with the specified flight
    /// and also have at least one other flight with a departure time greater than the departure time of the reference
    /// flight.
    /// </returns>
    public static Expression<Func<Baggage, bool>> GetBagsWithOnwardConnections(Guid flightId)
    {
        return b => b.Flights.Any(fb => fb.FlightId == flightId) && 
                    b.Flights.Where(fb => fb.FlightId == flightId && fb.Flight != null)
                        .Any(fb => b.Flights.Any(fb2 =>
                            fb2.Flight != null && 
                            fb2.Flight.DepartureDateTime > fb.Flight.DepartureDateTime));
    }
}
