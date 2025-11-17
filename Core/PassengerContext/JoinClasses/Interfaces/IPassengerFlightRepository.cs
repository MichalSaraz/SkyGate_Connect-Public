using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.JoinClasses.Entities;

namespace Core.PassengerContext.JoinClasses.Interfaces;

/// <summary>
/// Repository contract for operations on <see cref="PassengerFlight"/>
/// </summary>
public interface IPassengerFlightRepository
{
    /// <summary>
    /// Retrieves the highest currently assigned boarding sequence number for a given flight.
    /// </summary>
    /// <param name="flightId">The unique identifier of the <see cref="BaseFlight"/> whose sequence is queried.</param>
    /// <returns>
    /// A <see cref="Task{Int32}"/> that resolves to the highest boarding sequence number assigned
    /// for the specified flight. If no sequence numbers are assigned, returns 0.
    /// </returns>
    Task<int> GetHighestSequenceNumberOfTheFlightAsync(Guid flightId);
}