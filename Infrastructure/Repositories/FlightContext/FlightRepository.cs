using System.Linq.Expressions;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.Flights.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories.FlightContext;

/// <inheritdoc cref="IFlightRepository"/>
public class FlightRepository : BaseFlightRepository, IFlightRepository
{
    private readonly IMemoryCache _cache;

    public FlightRepository(AppDbContext context, IMemoryCache cache) : base(context)
    {
        _cache = cache;
    }

    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Set<Flight>().AnyAsync(f => f.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Flight> GetFlightByCriteriaAsync(Expression<Func<Flight, bool>> criteria, 
        bool tracked = false)
    {
        var CACHE_KEY = $"Flight_{criteria}_{tracked}";

        if (!tracked && _cache.TryGetValue(CACHE_KEY, out Flight cachedFlight))
        {
            return cachedFlight;
        }

        var flightQuery = _context.Set<Flight>().AsQueryable()
            .Include(_ => _.Airline)
            .Include(_ => _.ListOfBookedPassengers)
            .Where(criteria);

        if (!tracked)
        {
            flightQuery = flightQuery.AsNoTracking();
        }

        var flight = await flightQuery.FirstOrDefaultAsync();

        _cache.Set(CACHE_KEY, flight, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });

        return flight;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<Flight>> GetFlightsByCriteriaAsync(
        Expression<Func<Flight, bool>> criteria, bool tracked = false)
    {
        var flightsQuery = _context.Set<Flight>().AsQueryable()
            .Include(_ => _.ListOfBookedPassengers)
            .Include(_ => _.Seats)
            .Where(criteria);

        if (!tracked)
        {
            flightsQuery = flightsQuery.AsNoTracking();
        }

        var flights = await flightsQuery.ToListAsync();

        return flights;
    }

    /// <inheritdoc/>
    public override async Task<BaseFlight> GetFlightByIdAsync(Guid id, bool tracked = true)
    {
        var CACHE_KEY = $"Flight_{id}_{tracked}";

        if (!tracked && _cache.TryGetValue(CACHE_KEY, out BaseFlight cachedFlight))
        {
            return cachedFlight;
        }

        var flight = await base.GetFlightByIdAsync(id, tracked) as Flight;           

        _cache.Set(CACHE_KEY, flight, new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });

        return flight;
    }
        
    /// <inheritdoc/>
    public async Task<Flight> GetFlightDetailsByIdAsync(Guid id)
    {
        var flightQuery = _context.Set<Flight>().AsQueryable().AsNoTracking()
            .Include(_ => _.Airline)
            .Include(_ => _.ListOfBookedPassengers)
            .Include(_ => _.Seats)
            .Include(_ => _.ScheduledFlight)
            .Include(_ => _.Aircraft)
            .Include(_ => _.DestinationTo)
            .Include(_ => _.ListOfBookedPassengers)
            .ThenInclude(_ => _.PassengerOrItem)
            .Where(_ => _.Id == id);

        var flight = await flightQuery.FirstOrDefaultAsync();

        return flight;
    }
}