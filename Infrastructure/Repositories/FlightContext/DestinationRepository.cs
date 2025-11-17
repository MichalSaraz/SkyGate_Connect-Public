using System.Linq.Expressions;
using Core.FlightContext.ReferenceData.Entities;
using Core.FlightContext.ReferenceData.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.FlightContext;

/// <inheritdoc cref="IDestinationRepository"/>
public class DestinationRepository : IDestinationRepository
{
    private readonly AppDbContext _context;

    public DestinationRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Destination> GetDestinationByCriteriaAsync(Expression<Func<Destination, bool>> criteria)
    {
        return await _context.Destinations.AsNoTracking()
            .Where(criteria)
            .FirstOrDefaultAsync();
    }
}