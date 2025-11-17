using System.Linq.Expressions;
using Core.Abstractions;
using Core.BaggageContext.Entities;

namespace Core.BaggageContext.Interfaces;

/// <summary>
/// Repository contract for <see cref="Baggage"/> entities.
/// Extends <see cref="IGenericRepository{Baggage}"/> with baggage-specific queries such as lookup by tag number,
/// criteria-based retrieval and obtaining sequence values used for tag generation.
/// </summary>
public interface IBaggageRepository : IGenericRepository<Baggage>
{
    /// <summary>
    /// Retrieves baggage by its tag number.
    /// </summary>
    /// <param name="tagNumber">The tag number of the baggage to look up.</param>
    /// <returns>
    /// A <see cref="Task{Baggage}"/> that resolves to the matching <see cref="Baggage"/>, or <c>null</c> if no
    /// entity with the specified tag number is found.
    /// </returns>
    Task<Baggage> GetBaggageByTagNumber(string tagNumber);
        
    /// <summary>
    /// Retrieves a single baggage item that matches the specified <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">A predicate used to filter baggage entities.</param>
    /// <param name="tracked">When <c>true</c> the returned entity is tracked by the DbContext; when <c>false</c>
    /// the entity is queried with AsNoTracking to reduce overhead (default: <c>true</c>).</param>
    /// <returns>
    /// A <see cref="Task{Baggage}"/> that resolves to the matching <see cref="Baggage"/>, or <c>null</c> if no
    /// entity satisfies the criteria.
    /// </returns>
    Task<Baggage> GetBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria, bool tracked = true);

    /// <summary>
    /// Retrieves all baggage entities that satisfy the provided <paramref name="criteria"/>.
    /// </summary>
    /// <param name="criteria">A predicate used to filter baggage entities.</param>
    /// <param name="tracked">When <c>true</c> the returned entities are tracked by the DbContext; when <c>false</c>
    /// the entities are queried with AsNoTracking to reduce overhead (default: <c>false</c>).</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching <see cref="Baggage"/> items
    /// (see <see cref="IReadOnlyList{Baggage}"/>). The returned list may be empty when no entities match the criteria.
    /// </returns>
    Task<IReadOnlyList<Baggage>> GetAllBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria, 
        bool tracked = false);

    /// <summary>
    /// Retrieves the next integer value from a named database sequence.
    /// </summary>
    /// <param name="sequenceName">The database sequence name (for example used to generate baggage tag numbers).
    /// </param>
    /// <returns>
    /// A <see cref="Task{Int32}"/> that resolves to the next value of the requested sequence.
    /// </returns>
    Task<int> GetNextSequenceValueAsync(string sequenceName);
}