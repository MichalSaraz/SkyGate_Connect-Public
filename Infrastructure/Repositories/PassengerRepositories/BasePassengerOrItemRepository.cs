using System.Linq.Expressions;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PassengerRepositories;

/// <inheritdoc cref="IBasePassengerOrItemRepository{BasePassengerOrItem}"/>
public class BasePassengerOrItemRepository<T> : GenericRepository<T>, IBasePassengerOrItemRepository<T>
    where T : BasePassengerOrItem
{
    public BasePassengerOrItemRepository(AppDbContext context) : base(context)
    {            
    }

    /// <inheritdoc />
    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Passengers.AnyAsync(f => f.Id == id);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<BasePassengerOrItem>> GetPassengersOrItemsByCriteriaAsync(
        Expression<Func<BasePassengerOrItem, bool>> criteria, bool tracked)
    {
        var passengersOrItems = await _ConfigurePassengerOrItemQuery(tracked)
            .Where(p => EF.Property<string>(p, "PassengerOrItemType") != "Infant")
            .Where(criteria)
            .ToListAsync();

        return passengersOrItems;
    }

    /// <inheritdoc />
    public async Task<BasePassengerOrItem> GetPassengerOrItemByIdAsync(Guid id)
    {
        var passengerOrItem = await _ConfigurePassengerOrItemQuery(tracked: false)
            .Where(p => EF.Property<string>(p, "PassengerOrItemType") != "Infant")
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        return passengerOrItem;

    }
    
    /// <summary>
    /// Configures the base query for <see cref="BasePassengerOrItem"/> entities, including related data.
    /// </summary>
    private IQueryable<BasePassengerOrItem> _ConfigurePassengerOrItemQuery(bool tracked = true)
    {
        var query = _context.Passengers.AsQueryable();

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return query
            .Include(p => p.Flights)
            .ThenInclude(f => f.Flight)
            .Include(p => p.AssignedSeats)
            .ThenInclude(s => s.Flight)
            .Include(p => p.BookingDetails)
            .Include(p => p.TravelDocuments)
            .Include(p => p.Comments)
            .ThenInclude(c => c.LinkedToFlights)
            .ThenInclude(f => f.Flight);
    }
}