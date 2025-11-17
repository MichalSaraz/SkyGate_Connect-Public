using System.Linq.Expressions;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.OperationResults;

namespace Application.BaggageContext.Interfaces;

/// <summary>
/// Query contract that exposes read-only operations for retrieving baggage information and related queries.
/// Methods return a <see cref="Result"/> wrapper that contains the requested data on success or a
/// <c>NoDataResponse</c>/error details when the requested data cannot be found.
/// </summary>
public interface IBaggageQuery
{
    /// <summary>
    /// Retrieves baggage details for the provided tag number.
    /// </summary>
    /// <param name="tagNumber">The baggage tag number to look up (typically assigned at check-in).</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains the baggage details; if the baggage is not found, the result contains a <c>NoDataResponse</c>
    /// describing the failure (for example 404 Not Found).
    /// </returns>
    Task<Result> GetBaggageDetailsByTagNumberAsync(string tagNumber);
    
    /// <summary>
    /// Retrieves baggage records that satisfy the specified <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">A LINQ expression used to filter <see cref="Baggage"/> entities.</param>
    /// <param name="tracked">If <c>true</c> the returned entities are tracked by the DbContext; otherwise they are not
    /// tracked. Default is <c>false</c>.</param>
    /// <param name="expectedIds">Optional collection of expected baggage identifiers. When provided the query handler
    /// will verify that all specified ids are present; if any are missing the returned <see cref="Result"/> will
    /// contain a <c>NoDataResponse</c> describing the missing ids (typically 404).</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains a collection of matching <see cref="Baggage"/> entities; if no baggage matches the criteria,
    /// or if provided <paramref name="expectedIds"/> contains ids that were not found, the result contains
    /// a <c>NoDataResponse</c>.
    /// </returns>
    Task<Result> RetrieveAllBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria,
        bool tracked = false, IEnumerable<Guid>? expectedIds = null);
    
    /// <summary>
    /// Retrieves all baggage items for the specified flight.
    /// </summary>
    /// <param name="flightId">The identifier of the flight whose baggage should be retrieved.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains the list of baggage for the flight; if there are no bags for the flight, the result
    /// contains a <c>NoDataResponse</c> indicating the absence of data.
    /// </returns>
    Task<Result> GetAllBagsForFlightAsync(Guid flightId);

    /// <summary>
    /// Retrieves baggage for the given flight that are marked with a specific special bag type.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="specialBagType">The special bag type to filter by.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains matching baggage items; if none are found, the result contains a <c>NoDataResponse</c>.
    /// </returns>
    Task<Result> GetBagsBySpecialBagTypeAsync(Guid flightId, SpecialBagEnum specialBagType);

    /// <summary>
    /// Retrieves baggage for the given flight filtered by baggage type (local, transfer).
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="baggageType">The baggage type to filter by.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains matching baggage items; if none are found, the result contains a <c>NoDataResponse</c>.
    /// </returns>
    Task<Result> GetBagsByBaggageTypeAsync(Guid flightId, BaggageTypeEnum baggageType);

    /// <summary>
    /// Retrieves inactive baggage items for a flight. Inactive bags represent items without issued baggage tags.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains the inactive baggage collection; if none are found, the result contains a <c>NoDataResponse</c>.
    /// </returns>
    Task<Result> GetInactiveBagsAsync(Guid flightId);

    /// <summary>
    /// Retrieves baggage that have onward connections (i.e., baggage that continues to another flight).
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a <see cref="Result"/>. On success the <see cref="Result"/>
    /// contains baggage items with onward connections; if none are found, the result contains a <c>NoDataResponse</c>.
    /// </returns>
    Task<Result> GetBagsWithOnwardConnectionsAsync(Guid flightId);
}
