using System.Linq.Expressions;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Passengers.Interfaces;

/// <summary>
/// Repository contract for <see cref="Infant"/> entities. Extends <see cref="IBasePassengerOrItemRepository{Infant}"/>
/// with queries specific to infants.
/// </summary>
public interface IInfantRepository : IBasePassengerOrItemRepository<Infant>
{
    /// <summary>
    /// Asynchronously retrieves an <see cref="Infant"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="Infant"/> to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{Infant}"/> that resolves to the found <see cref="Infant"/>, or <c>null</c> if no matching
    /// entity is found.
    /// </returns>
    Task<Infant> GetInfantByIdAsync(Guid id);

    /// <summary>
    /// Asynchronously returns a read-only list of <see cref="Infant"/> entities that match the specified criteria.
    /// </summary>
    /// <param name="criteria">The filter expression to apply to <see cref="Infant"/> entities.</param>
    /// <param name="tracked">Indicates whether the DbContext should track the returned entities. Default is
    /// <c>false</c>.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching <see cref="Infant"/> instances
    /// (see <see cref="IReadOnlyList{Infant}"/>). The returned list may be empty if no entities match the criteria.
    /// </returns>
    Task<IReadOnlyList<Infant>> GetInfantsByCriteriaAsync(Expression<Func<Infant, bool>> criteria,
        bool tracked = false);
}