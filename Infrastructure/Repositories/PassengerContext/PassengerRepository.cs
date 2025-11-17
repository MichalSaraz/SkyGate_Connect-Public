using System.Linq.Expressions;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories.PassengerContext;

/// <inheritdoc cref="IPassengerRepository"/>
public class PassengerRepository : BasePassengerOrItemRepository<Passenger>, IPassengerRepository
{
    private readonly IMemoryCache _cache;

    public PassengerRepository(AppDbContext context, IMemoryCache cache) : base(context)
    {
        _cache = cache;
    }

    /// <inheritdoc/>
    public override async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Set<Passenger>().AnyAsync(f => f.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Passenger> GetPassengerByCriteriaAsync(Expression<Func<Passenger, bool>> criteria)
    {
        return await _context.Set<Passenger>().AsQueryable().AsNoTracking()
            .Include(_ => _.SpecialServiceRequests)
            .Where(criteria)
            .SingleOrDefaultAsync();
    }

    /// <inheritdoc/>
    public async Task<Passenger> GetPassengerByIdAsync(Guid id, bool tracked = true)
    { 
        var passengerQuery = _context.Set<Passenger>().AsQueryable()
            .Include(_ => _.BookingDetails)
            .ThenInclude(_ => _.PNR)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Include(_ => _.AssignedSeats)
            .ThenInclude(_ => _.Flight)
            .Include(_ => _.Infant.BookingDetails)
            .Include(_ => _.Infant)
            .ThenInclude(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Where(_ => _.Id == id);
            
        if (!tracked)
        {
            passengerQuery = passengerQuery.AsNoTracking();
        }

        var passenger = await passengerQuery.SingleOrDefaultAsync();

        return passenger;
    }
 
    /// <inheritdoc/>
    public async Task<IReadOnlyList<Passenger>> GetPassengersByIdAsync(IEnumerable<Guid> ids, bool tracked = true)
    {
        var query = _context.Set<Passenger>().AsQueryable()
            .Include(_ => _.BookingDetails)
            .ThenInclude(_ => _.PNR)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Include(_ => _.AssignedSeats)
            .ThenInclude(_ => _.Flight)
            .Include(_ => _.Infant.BookingDetails)
            .Include(_ => _.Infant)
            .ThenInclude(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Where(_ => ids.Contains(_.Id));

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }
 
    /// <inheritdoc/>
    public async Task<Passenger> GetPassengerDetailsByIdAsync(Guid id, bool tracked = true)
    {
        var CACHE_KEY = $"Passenger_{id}_{tracked}";

        return await _GetOrSetCacheAsync(CACHE_KEY, async () =>
        {
            return await _ConfigurePassengerQuery(tracked)
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();
        });
    }
 
    /// <inheritdoc/>
    public async Task<Passenger> GetPassengerDetailsByFlightAndIdAsync(Guid flightId, Guid passengerId, 
        bool tracked = true)
    {
        var CACHE_KEY = $"Passenger_{passengerId}_{flightId}_{tracked}";

        return await _GetOrSetCacheAsync(CACHE_KEY, async () =>
        {
            return await _ConfigurePassengerQuery(tracked)
                .Where(p => p.Id == passengerId && 
                            p.Flights.Any(f => f.FlightId == flightId))
                .SingleOrDefaultAsync();
        });
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<Passenger>> GetPassengersWithFlightConnectionsAsync(Guid flightId,
        bool isOnwardFlight)
    {
        var passengerQuery = _context.Set<Passenger>().AsQueryable().AsNoTracking()
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Include(_ => _.PassengerCheckedBags)
            .Include(_ => _.AssignedSeats)
            .Where(_ => _.Flights.Any(_ => _.FlightId == flightId));

        if (isOnwardFlight)
        {
            passengerQuery = passengerQuery.Where(p => p.Flights.Any(_ =>
                _.Flight.DepartureDateTime >
                p.Flights.FirstOrDefault(_ => _.FlightId == flightId).Flight.DepartureDateTime));
        }
        else
        {
            passengerQuery = passengerQuery.Where(p => p.Flights.Any(_ =>
                _.Flight.DepartureDateTime <
                p.Flights.FirstOrDefault(_ => _.FlightId == flightId).Flight.DepartureDateTime));
        }

        return await passengerQuery.ToListAsync();
    }

    /// <summary>
    /// Configures the passenger query with all necessary includes.
    /// </summary>
    private IQueryable<Passenger> _ConfigurePassengerQuery(bool tracked = true)
    {
        var query = _context.Set<Passenger>().AsQueryable();

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return query
            .Include(p => p.BookingDetails)
            .ThenInclude(b => b.PNR)
            .Include(p => p.Flights)
            .ThenInclude(f => f.Flight)
            .Include(p => p.AssignedSeats)
            .ThenInclude(s => s.Flight)
            .Include(p => p.Infant.BookingDetails)
            .Include(p => p.Infant)
            .ThenInclude(i => i.Flights)
            .ThenInclude(f => f.Flight)
            .Include(p => p.PassengerCheckedBags)
            .ThenInclude(b => b.BaggageTag)
            .Include(p => p.PassengerCheckedBags)
            .ThenInclude(b => b.SpecialBag)
            .Include(p => p.PassengerCheckedBags)
            .ThenInclude(b => b.FinalDestination)
            .Include(p => p.PassengerCheckedBags)
            .ThenInclude(b => b.Flights)
            .ThenInclude(f => f.Flight)
            .Include(p => p.SpecialServiceRequests)
            .ThenInclude(ss => ss.SSRCode)
            .Include(p => p.SpecialServiceRequests)
            .ThenInclude(ss => ss.Flight)
            .Include(p => p.TravelDocuments)
            .Include(p => p.Comments)
            .ThenInclude(c => c.LinkedToFlights)
            .ThenInclude(f => f.Flight);
    }
     
    /// <summary>
    /// Retrieves an item from the cache or sets it if not present.
    /// </summary>
    private async Task<T> _GetOrSetCacheAsync<T>(string cacheKey, Func<Task<T>> fetchFunction) where T : class
    {
        if (_cache.TryGetValue(cacheKey, out T cachedItem))
        {
            return cachedItem;
        }

        var fetchedItem = await fetchFunction.Invoke();

        _cache.Set(cacheKey, fetchedItem, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });

        return fetchedItem;
    }
}