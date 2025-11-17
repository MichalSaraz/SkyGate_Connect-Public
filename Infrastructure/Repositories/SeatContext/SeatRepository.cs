using System.Linq.Expressions;
using Core.SeatContext.Entities;
using Core.SeatContext.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SeatContext;

/// <inheritdoc cref="ISeatRepository"/>
public class SeatRepository : GenericRepository<Seat>, ISeatRepository
{
    public SeatRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<Seat>> GetSeatsByCriteriaAsync(Expression<Func<Seat, bool>> criteria,
        bool tracked = true)
    {
        var seatQuery = _context.Seats.AsQueryable()
            .Include(_ => _.PassengerOrItem)
            .ThenInclude(_ => _.Flights)
            .Include(_ => _.PassengerOrItem)
            .ThenInclude(_ => _.Comments)
            .Include(_ => _.Flight)
            .Where(criteria);

        if (!tracked)
        {
            seatQuery = seatQuery.AsNoTracking();
        }

        var seats = await seatQuery.ToListAsync();

        return seats;
    }

    /// <inheritdoc/>
    public async Task<Seat> GetSeatByCriteriaAsync(Expression<Func<Seat, bool>> criteria)
    {
        return await _context.Seats.AsNoTracking().Where(criteria).FirstOrDefaultAsync();
    }
}