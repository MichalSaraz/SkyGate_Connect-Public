using System.Linq.Expressions;
using Core.FlightContext.ReferenceData.Entities;

namespace Core.FlightContext.ReferenceData.Interfaces;

/// <summary>
/// Defines the contract for a repository that manages <see cref="Destination"/> entities.
/// </summary>
public interface IDestinationRepository
{
    /// <summary>
    /// Retrieves a <see cref="Destination"/> entity that matches the specified criteria.
    /// </summary>
    /// <param name="criteria">An expression defining the filtering criteria for the <see cref="Destination"/> entity.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation. The task result contains the matching
    /// <see cref="Destination"/>, or <c>null</c> if no entity satisfies the criteria.
    /// </returns>
    Task<Destination> GetDestinationByCriteriaAsync(Expression<Func<Destination, bool>> criteria);
}