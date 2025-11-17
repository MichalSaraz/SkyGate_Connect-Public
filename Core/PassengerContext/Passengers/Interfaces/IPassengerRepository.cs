using System.Linq.Expressions;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Passengers.Interfaces;

/// <summary>
/// Repository contract for <see cref="Passenger"/> entities.
/// Extends <see cref="IBasePassengerOrItemRepository{Passenger}"/> with passenger-specific queries such as
/// retrieval by criteria, detailed lookup and flight-connection related queries.
/// </summary>
public interface IPassengerRepository : IBasePassengerOrItemRepository<Passenger>
{
    /// <summary>
    /// Retrieves the first <see cref="Passenger"/> that matches the specified criteria.
    /// </summary>
    /// <param name="criteria">The filter expression to apply.</param>
    /// <returns>
    /// A <see cref="Task{Passenger}"/> that resolves to the matching <see cref="Passenger"/>, or <c>null</c>
    /// if no entity satisfies the criteria.
    /// </returns>
    Task<Passenger> GetPassengerByCriteriaAsync(Expression<Func<Passenger, bool>> criteria);

    /// <summary>
    /// Retrieves a <see cref="Passenger"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the passenger to retrieve.</param>
    /// <param name="tracked">Indicates whether the returned entity should be tracked by the DbContext. Default is
    /// <c>true</c>.</param>
    /// <returns>
    /// A <see cref="Task{Passenger}"/> that resolves to the matching <see cref="Passenger"/>, or <c>null</c>
    /// if no passenger with the specified identifier exists.
    /// </returns>
    Task<Passenger> GetPassengerByIdAsync(Guid id, bool tracked = true);

    /// <summary>
    /// Retrieves a read-only list of <see cref="Passenger"/> entities whose identifiers are included in the provided
    /// collection.
    /// </summary>
    /// <param name="ids">A collection of passenger identifiers to retrieve.</param>
    /// <param name="tracked">Indicates whether the returned entities should be tracked by the DbContext. Default is
    /// <c>true</c>.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching passengers (see
    /// <see cref="IReadOnlyList{Passenger}"/>). The list may be empty if no identifiers match existing entities.
    /// </returns>
    Task<IReadOnlyList<Passenger>> GetPassengersByIdAsync(IEnumerable<Guid> ids, bool tracked = true);

    /// <summary>
    /// Retrieves detailed information for a passenger by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the passenger.</param>
    /// <param name="tracked">Indicates whether the returned entity should be tracked by the DbContext. Default is
    /// <c>true</c>.</param>
    /// <returns>
    /// A <see cref="Task{Passenger}"/> that resolves to the passenger with full details, or <c>null</c>
    /// if no matching entity is found.
    /// </returns>
    Task<Passenger> GetPassengerDetailsByIdAsync(Guid id, bool tracked = true);

    /// <summary>
    /// Retrieves the passenger details for a specific flight by flightId and passengerId.
    /// </summary>
    /// <param name="flightId">The identifier of the flight.</param>
    /// <param name="passengerId">The identifier of the passenger.</param>
    /// <param name="tracked">Indicates whether the returned entity should be tracked by the DbContext. Default is
    /// <c>true</c>.</param>
    /// <returns>
    /// A <see cref="Task{Passenger}"/> that resolves to the passenger details for the specified flight, or <c>null</c>
    /// if no matching entity is found.
    /// </returns>
    Task<Passenger> GetPassengerDetailsByFlightAndIdAsync(Guid flightId, Guid passengerId,
        bool tracked = true);

    /// <summary>
    /// Retrieves passengers that have flight connections for the specified flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight.</param>
    /// <param name="isOnwardFlight">If <c>true</c> retrieves onward connections; if <c>false</c> retrieves inbound
    /// connections.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of passengers with the requested flight connections
    /// (see <see cref="IReadOnlyList{Passenger}"/>). The list may be empty when no connections are found.
    /// </returns>
    Task<IReadOnlyList<Passenger>> GetPassengersWithFlightConnectionsAsync(Guid flightId, bool isOnwardFlight);
}