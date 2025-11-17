using System.Linq.Expressions;
using Core.Abstractions;
using Core.FlightContext.Flights.Entities;

namespace Core.FlightContext.Flights.Interfaces;

/// <summary>
/// Contract for a repository that manages <see cref="BaseFlight"/> entities.
/// Extends the generic <see cref="IGenericRepository{BaseFlight}"/> with flight-specific data access methods.
/// </summary>
public interface IBaseFlightRepository : IGenericRepository<BaseFlight>
{
    /// <summary>
    /// Retrieves all flights that match the specified <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">The criteria used to filter the flights.</param>
    /// <param name="tracked">Indicates whether the DbContext should track the fetched flights. When <c>false</c>
    /// the query should be executed with <c>AsNoTracking()</c> to reduce change-tracking overhead. Default is
    /// <c>false</c> (no tracking).</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching flights
    /// (see <see cref="IReadOnlyList{BaseFlight}"/>). The returned collection may be empty when no flights satisfy
    /// the criteria.
    /// </returns>
    Task<IReadOnlyList<BaseFlight>> GetFlightsByCriteriaAsync(Expression<Func<BaseFlight, bool>> criteria,
        bool tracked = false);

    /// <summary>
    /// Retrieves a base flight with the specified identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the flight to retrieve.</param>
    /// <param name="tracked">Indicates whether the DbContext should track the retrieved flight. Default is <c>true</c>
    /// (tracked).</param>
    /// <returns>
    /// A <see cref="Task{BaseFlight}"/> that resolves to the requested <see cref="BaseFlight"/> when found;
    /// otherwise the result may be <c>null</c>.
    /// </returns>
    Task<BaseFlight> GetFlightByIdAsync(Guid id, bool tracked = true);
}