using System.Linq.Expressions;
using Core.PassengerContext.TravelDocuments.Entities;
using Core.PassengerContext.TravelDocuments.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TravelDocumentContext;

/// <inheritdoc cref="ICountryRepository"/>
public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Country> GetCountryByCriteriaAsync(Expression<Func<Country, bool>> criteria)
    {
        return await _context.Countries.AsNoTracking()
            .Where(criteria)
            .FirstOrDefaultAsync();
    }
}