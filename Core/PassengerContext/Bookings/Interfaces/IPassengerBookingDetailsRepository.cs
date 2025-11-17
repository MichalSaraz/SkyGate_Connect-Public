using System.Linq.Expressions;
using Core.Abstractions;
using Core.PassengerContext.Bookings.Entities;

namespace Core.PassengerContext.Bookings.Interfaces;
/// <summary>
/// Repository contract for <see cref="PassengerBookingDetails"/> entities. Extends
/// <see cref="IGenericRepository{PassengerBookingDetails}"/> with queries specific to passenger booking details.
/// </summary>
public interface IPassengerBookingDetailsRepository : IGenericRepository<PassengerBookingDetails>
{
    /// <summary>
    /// Retrieves <see cref="PassengerBookingDetails"/> based on the given criteria.
    /// </summary>
    /// <param name="criteria">The expression defining the criteria to search for.</param>
    /// <returns>
    /// A <see cref="Task{PassengerBookingDetails}"/> that resolves to the matching
    /// <see cref="PassengerBookingDetails"/>, or <c>null</c> if no entity satisfies the criteria.
    /// </returns>
    Task<PassengerBookingDetails> GetBookingDetailsByCriteriaAsync(
        Expression<Func<PassengerBookingDetails, bool>> criteria);
}