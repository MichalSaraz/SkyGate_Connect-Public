using System.Linq.Expressions;
using Core.PassengerContext.SpecialServiceRequests.Entities;
using Core.PassengerContext.SpecialServiceRequests.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SpecialServiceRequestsRepositories;

/// <inheritdoc cref="ISpecialServiceRequestRepository"/>
public class SpecialServiceRequestRepository : GenericRepository<SpecialServiceRequest>,
    ISpecialServiceRequestRepository
{
    public SpecialServiceRequestRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<SpecialServiceRequest>> GetSpecialServiceRequestsByCriteriaAsync(
        Expression<Func<SpecialServiceRequest, bool>> criteria)
    {
        return await _context.SpecialServiceRequests.AsQueryable().AsNoTracking()
            .Include(_ => _.SSRCode)
            .Include(_ => _.Passenger)
            .Include(_ => _.Passenger.AssignedSeats)
            .Include(_ => _.Passenger.BookingDetails)
            .Include(_ => _.Flight)
            .Where(criteria)
            .ToListAsync();
    }
}