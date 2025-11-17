using System.Linq.Expressions;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.Flights.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.FlightRepositories;

/// <inheritdoc cref="IOtherFlightRepository"/>
public class OtherFlightRepository : BaseFlightRepository, IOtherFlightRepository
{
    public OtherFlightRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<OtherFlight> GetOtherFlightByCriteriaAsync(Expression<Func<OtherFlight, bool>> criteria,
        bool tracked = false)
    {
        var flightQuery = _context.Set<OtherFlight>()
            .AsQueryable()
            .Include(_ => _.Airline)
            .Include(_ => _.ListOfBookedPassengers)
            .Where(criteria);

        if (!tracked)
        {
            flightQuery = flightQuery.AsNoTracking();
        }

        var flight = await flightQuery.FirstOrDefaultAsync();

        return flight;
    }
}