using System.Data;
using System.Linq.Expressions;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories.BaggageContext.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.BaggageContext;

/// <inheritdoc cref="IBaggageRepository"/>
public class BaggageRepository : GenericRepository<Baggage>, IBaggageRepository
{
    private readonly ILogger<BaggageRepository> _logger;

    public BaggageRepository(AppDbContext context, ILogger<BaggageRepository> logger) : base(context)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Baggage> GetBaggageByTagNumber(string tagNumber)
    {
        _logger.SearchingByTag(tagNumber);
            
        var baggage = await _context.Baggage.AsNoTracking()
            .Include(_ => _.Passenger)
            .Include(_ => _.BaggageTag)
            .Include(_ => _.SpecialBag)
            .Include(_ => _.FinalDestination)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .FirstOrDefaultAsync(_ => _.BaggageTag.TagNumber == tagNumber);

        if (baggage == null)
        {
            _logger.BaggageNotFound(tagNumber);
        }
        else
        {
            _logger.BaggageFound(tagNumber, baggage.Id);
        }

        return baggage;
    }
    
    /// <inheritdoc />
    public async Task<Baggage> GetBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria,
        bool tracked = true)
    {
        _logger.SearchingByCriteria(tracked);
            
        var baggageQuery = _context.Baggage.AsQueryable()
            .Include(_ => _.Passenger)
            .Include(_ => _.BaggageTag)
            .Include(_ => _.SpecialBag)
            .Include(_ => _.Flights)
            .Include(_ => _.FinalDestination)
            .Where(criteria);
            
        if (!tracked)
        {
            baggageQuery = baggageQuery.AsNoTracking();
        }
            
        var baggage = await baggageQuery.FirstOrDefaultAsync();
            
        if (baggage == null)
        {
            _logger.CriteriaNotFound();
        }
        else
        {
            _logger.CriteriaFound(baggage.Id);
        }
            
        return baggage;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Baggage>> GetAllBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria,
        bool tracked = false)
    {
        _logger.SearchingAllByCriteria(tracked);
            
        var baggageQuery = _context.Baggage.AsQueryable()
            .Include(_ => _.Passenger)
            .Include(_ => _.BaggageTag)
            .Include(_ => _.SpecialBag)
            .Include(_ => _.FinalDestination)
            .Include(_ => _.Flights)
            .ThenInclude(_ => _.Flight)
            .Where(criteria);
                
        if (!tracked)
        {
            baggageQuery = baggageQuery.AsNoTracking();
        }
            
        var baggageList = await baggageQuery.ToListAsync();
            
        _logger.FoundItems(baggageList.Count);
            
        return baggageList;
    }

    /// <inheritdoc />
    public async Task<int> GetNextSequenceValueAsync(string sequenceName)
    {
        _logger.GettingNextSequence(sequenceName);
            
        var connection = _context.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT nextval('\"{sequenceName}\"')";
        var nextValue = await cmd.ExecuteScalarAsync();
            
        _logger.NextSequenceValue(sequenceName, nextValue);
            
        return Convert.ToInt32(nextValue);
    }
}