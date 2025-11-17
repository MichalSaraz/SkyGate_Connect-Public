using System.Linq.Expressions;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PassengerContext;

/// <inheritdoc cref="IInfantRepository"/>
public class InfantRepository : BasePassengerOrItemRepository<Infant>, IInfantRepository
{
    public InfantRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public override async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Set<Infant>().AnyAsync(f => f.Id == id);
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<Infant>> GetInfantsByCriteriaAsync(Expression<Func<Infant, bool>> criteria, 
        bool tracked = false)
    {
        var infantsQuery = _context.Set<Infant>().AsQueryable()
            .Include(_ => _.BookingDetails)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Where(criteria);

        if (!tracked)
        {
            infantsQuery = infantsQuery.AsNoTracking();
        }

        var infants = await infantsQuery.ToListAsync();

        return infants;
    }

    /// <inheritdoc/>
    public async Task<Infant> GetInfantByIdAsync(Guid id)
    {
        var infantQuery = _context.Set<Infant>().AsQueryable()
            .Include(_ => _.BookingDetails)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Where(_ => _.Id == id);

        return await infantQuery.FirstOrDefaultAsync();
    }
}