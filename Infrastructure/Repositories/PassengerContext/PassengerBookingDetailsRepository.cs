using System.Linq.Expressions;
using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Bookings.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PassengerContext;

/// <inheritdoc cref="IPassengerBookingDetailsRepository"/>
public class PassengerBookingDetailsRepository : GenericRepository<PassengerBookingDetails>,
    IPassengerBookingDetailsRepository
{
    public PassengerBookingDetailsRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<PassengerBookingDetails> GetBookingDetailsByCriteriaAsync(
        Expression<Func<PassengerBookingDetails, bool>> criteria)
    {
        return await _context.PassengerBookingDetails.AsNoTracking()
            .Include(_ => _.PassengerOrItem)
            .Include(_ => _.PNR)
            .Where(criteria)
            .FirstOrDefaultAsync();
    }
}