using System.Linq.Expressions;
using Core.Abstractions;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Passengers.Interfaces;

/// <summary>
/// Repository contract for entities derived from <see cref="BasePassengerOrItem"/>. Extends the generic
/// <see cref="IGenericRepository{T}"/> with passenger-or-item specific operations such as existence checks
/// and convenient criteria-based lookups with optional tracking.
/// </summary>
/// <typeparam name="T">The concrete entity type managed by the repository. Must inherit from
/// <see cref="BasePassengerOrItem"/>.</typeparam>
public interface IBasePassengerOrItemRepository<T> : IGenericRepository<T> where T : BasePassengerOrItem
{
    /// <summary>
    /// Checks whether an entity with the specified identifier exists.
    /// </summary>
    /// <param name="id">The identifier of the entity to check.</param>
    /// <returns>
    /// A <see cref="Task{Boolean}"/> that resolves to <c>true</c> if an entity with the specified <paramref name="id"/>
    /// exists; otherwise <c>false</c>.
    /// </returns>
    Task<bool> ExistsAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves a read-only list of <see cref="BasePassengerOrItem"/> entities that match
    /// the specified criteria.
    /// </summary>
    /// <param name="criteria">The filter expression to apply to <see cref="BasePassengerOrItem"/> entities.</param>
    /// <param name="tracked">Indicates whether the returned entities should be tracked by the DbContext. Default is
    /// <c>true</c>.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching <see cref="BasePassengerOrItem"/>
    /// instances (see <see cref="IReadOnlyList{BasePassengerOrItem}"/>). The result may be an empty list if no
    /// entities match.
    /// </returns>
    Task<IReadOnlyList<BasePassengerOrItem>> GetPassengersOrItemsByCriteriaAsync(
        Expression<Func<BasePassengerOrItem, bool>> criteria, bool tracked = true);

    /// <summary>
    /// Asynchronously retrieves a <see cref="BasePassengerOrItem"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the passenger or item to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{BasePassengerOrItem}"/> that resolves to the matching <see cref="BasePassengerOrItem"/>,
    /// or <c>null</c> if no entity with the specified identifier exists.
    /// </returns>
    Task<BasePassengerOrItem> GetPassengerOrItemByIdAsync(Guid id);
}