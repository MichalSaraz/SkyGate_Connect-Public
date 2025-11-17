using System.Linq.Expressions;
using Core.FlightContext.Flights.Entities;

namespace Core.FlightContext.Flights.Interfaces;

/// <summary>
/// Repository contract for <see cref="OtherFlight"/> entities. Extends <see cref="IBaseFlightRepository"/> with
/// queries specific to this type.
/// </summary>
public interface IOtherFlightRepository : IBaseFlightRepository
{
    /// <summary>
    /// Retrieves a single <see cref="OtherFlight"/> that satisfies the specified <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">The predicate expression used to filter <see cref="OtherFlight"/> entities.</param>
    /// <param name="tracked">When <c>true</c> the returned entity is tracked by the DbContext; when <c>false</c>
    /// the query should be executed with <c>AsNoTracking()</c> for better read performance. Default is
    /// <c>false</c>.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to the first matching <see cref="OtherFlight"/>, or <c>null</c> if no
    /// match is found.
    /// </returns>
    Task<OtherFlight> GetOtherFlightByCriteriaAsync(Expression<Func<OtherFlight, bool>> criteria,
        bool tracked = false);
}