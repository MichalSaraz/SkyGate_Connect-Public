using Core.PassengerContext.JoinClasses.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PassengerContext;

/// <inheritdoc cref="IPassengerFlightRepository"/>
public class PassengerFlightRepository : IPassengerFlightRepository
{
    private readonly AppDbContext _context;

    public PassengerFlightRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<int> GetHighestSequenceNumberOfTheFlightAsync(Guid flightId)
    {
        var highestSequenceNumber = await _context.PassengerFlight
            .AsQueryable()
            .AsNoTracking()
            .Where(_ => _.FlightId == flightId)
            .MaxAsync(_ => _.BoardingSequenceNumber) ?? 0;

        return highestSequenceNumber;
    }
}