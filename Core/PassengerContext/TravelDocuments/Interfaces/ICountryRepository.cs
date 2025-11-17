using System.Linq.Expressions;
using Core.PassengerContext.TravelDocuments.Entities;

namespace Core.PassengerContext.TravelDocuments.Interfaces;

/// <summary>
/// Defines the contract for a repository that manages <see cref="Country"/> entities.
/// </summary>
public interface ICountryRepository
{
    /// <summary>
    /// Retrieves a single <see cref="Country"/> based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The expression representing the criteria to filter the <see cref="Country"/> objects.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation, containing the matching <see cref="Country"/>
    /// instance, or <c>null</c> if no entity satisfies the criteria.
    /// </returns>
    Task<Country> GetCountryByCriteriaAsync(Expression<Func<Country, bool>> criteria);
}