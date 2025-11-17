using System.Linq.Expressions;
using Core.Abstractions;
using Core.SeatContext.Entities;

namespace Core.SeatContext.Interfaces;

/// <summary>
/// Repository contract for <see cref="Seat"/> entities. Extends <see cref="IGenericRepository{Seat}"/> with
/// seat-specific queries.
/// </summary>
public interface ISeatRepository : IGenericRepository<Seat>
{
    /// <summary>
    /// Retrieves a list of seats based on a given criteria.
    /// </summary>
    /// <param name="criteria">The criteria to filter the seats.</param>
    /// <param name="tracked">Indicates whether the seats should be tracked for changes. Defaults is true.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching <see cref="Seat"/> instances
    /// (see <see cref="IReadOnlyList{Seat}"/>). The list may be empty when no seats match the criteria.
    /// </returns>
    Task<IReadOnlyList<Seat>> GetSeatsByCriteriaAsync(Expression<Func<Seat, bool>> criteria, bool tracked = true);

    /// <summary>
    /// Retrieves a seat that matches the given criteria.
    /// </summary>
    /// <param name="criteria">The criteria to filter the seat.</param>
    /// <returns>
    /// A <see cref="Task{Seat}"/> that resolves to the matching <see cref="Seat"/>, or <c>null</c> if no entity
    /// satisfies the criteria.
    /// </returns>
    Task<Seat> GetSeatByCriteriaAsync(Expression<Func<Seat, bool>> criteria);
}