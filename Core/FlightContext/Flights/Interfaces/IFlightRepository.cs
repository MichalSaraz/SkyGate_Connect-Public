using System.Linq.Expressions;
using Core.FlightContext.Flights.Entities;

namespace Core.FlightContext.Flights.Interfaces;

/// <summary>
/// Repository contract for <see cref="Flight"/> data access operations.
/// Extends <see cref="IBaseFlightRepository"/> with flight-specific queries such as existence checks,
/// criteria-based retrieval and detailed flight data access.
/// </summary>
public interface IFlightRepository : IBaseFlightRepository
{
    /// <summary>
    /// Checks whether a flight with the specified identifier exists in the data store.
    /// </summary>
    /// <param name="flightId">The identifier of the flight to check.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to <c>true</c> when a flight with the given id exists; otherwise <c>false</c>.
    /// </returns>
    Task<bool> ExistsAsync(Guid flightId);

    /// <summary>
    /// Retrieves a list of flights that satisfy the provided <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">A predicate expression used to filter flight entities.</param>
    /// <param name="tracked">When <c>true</c> the returned entities are tracked by the DbContext; when <c>false</c>
    /// the query is executed with <c>AsNoTracking()</c> for better read performance. Default: <c>false</c>.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only collection of matching flights
    /// (see <see cref="IReadOnlyList{Flight}"/>). The collection may be empty when no flights match the criteria.
    /// </returns>
    Task<IReadOnlyList<Flight>> GetFlightsByCriteriaAsync(
        Expression<Func<Flight, bool>> criteria, bool tracked = false);

    /// <summary>
    /// Retrieves a single flight that satisfies the specified <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">A predicate expression used to identify the flight.</param>
    /// <param name="tracked">When <c>true</c> the returned entity is tracked by the DbContext; when <c>false</c>
    /// the query is executed with <c>AsNoTracking()</c>. Default is <c>false</c>.</param>
    /// <returns>
    /// A <see cref="Task{Flight}"/> that resolves to the matching <see cref="Flight"/>, or <c>null</c> if
    /// no matching flight is found.
    /// </returns>
    Task<Flight> GetFlightByCriteriaAsync(Expression<Func<Flight, bool>> criteria, bool tracked = false);

    /// <summary>
    /// Retrieves the flight details for the specified flight identifier.
    /// </summary>
    /// <param name="id">The identifier of the flight whose details should be retrieved.</param>
    /// <returns>
    /// A <see cref="Task{Flight}"/> that resolves to the <see cref="Flight"/> details, or <c>null</c> when the flight
    /// cannot be found.
    /// </returns>
    Task<Flight> GetFlightDetailsByIdAsync(Guid id);
}