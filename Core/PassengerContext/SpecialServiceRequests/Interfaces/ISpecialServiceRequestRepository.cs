using System.Linq.Expressions;
using Core.Abstractions;
using Core.PassengerContext.SpecialServiceRequests.Entities;

namespace Core.PassengerContext.SpecialServiceRequests.Interfaces;

/// <summary>
/// Repository contract for <see cref="SpecialServiceRequest"/> entities. Extends
/// <see cref="IGenericRepository{SpecialServiceRequest}"/> with queries specific to special service requests.
/// </summary>
public interface ISpecialServiceRequestRepository : IGenericRepository<SpecialServiceRequest>
{
    /// <summary>
    /// Retrieves special service requests based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria to filter the special service requests.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching
    /// <see cref="SpecialServiceRequest"/> entries (see <see cref="IReadOnlyList{SpecialServiceRequest}"/>).
    /// The list may be empty when no requests match the criteria.
    /// </returns>
    Task<IReadOnlyList<SpecialServiceRequest>> GetSpecialServiceRequestsByCriteriaAsync(
        Expression<Func<SpecialServiceRequest, bool>> criteria);
}