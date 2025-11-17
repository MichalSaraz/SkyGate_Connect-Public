using System.Linq.Expressions;
using Application.Abstractions;
using Application.BaggageContext.Expressions;
using Application.BaggageContext.Interfaces;
using Application.FlightContext.Interfaces;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.BaggageContext.Interfaces;
using Core.OperationResults;

namespace Application.BaggageContext.Queries;

/// <inheritdoc cref="IBaggageQuery"/>
public class BaggageQuery : QueryBase<Guid>, IBaggageQuery
{
    private readonly IBaggageRepository _baggageRepository;
    private readonly IFlightQuery _flightQuery;

    public BaggageQuery(
        IBaggageRepository baggageRepository,
        IFlightQuery flightQuery)
    {
        _baggageRepository = baggageRepository;
        _flightQuery = flightQuery;
    }

    /// <inheritdoc/>
    public async Task<Result> GetBaggageDetailsByTagNumberAsync(string tagNumber)
    {
        return await _HandleScalarRequestAsync(
            () => _baggageRepository.GetBaggageByTagNumber(tagNumber),
            $"Baggage with tag number {tagNumber} was not found.");
    }
    
    /// <inheritdoc/>
    public async Task<Result> RetrieveAllBaggageByCriteriaAsync(Expression<Func<Baggage, bool>> criteria,
        bool tracked = false, IEnumerable<Guid>? expectedIds = null)
    {
        return await _HandleCollectionRequestAsync<IReadOnlyList<Baggage>, Baggage>(
            () => _baggageRepository.GetAllBaggageByCriteriaAsync(criteria, tracked),
            "No baggage with provided criteria were found.",
            expectedIds);
    }

    /// <inheritdoc/>
    public Task<Result> GetAllBagsForFlightAsync(Guid flightId)
    {
        return _GetBagsWithCriteria(
            flightId,
            BaggageCriteria.GetAllBagsForFlight,
            "No bags found for this flight.");
    }

    /// <inheritdoc/>
    public Task<Result> GetBagsBySpecialBagTypeAsync(Guid flightId, SpecialBagEnum specialBagType)
    {
        return _GetBagsWithCriteria(
            flightId,
            id => BaggageCriteria.GetBagsBySpecialBagType(id, specialBagType),
            $"No {specialBagType} found for this flight.");
    }

    /// <inheritdoc/>
    public Task<Result> GetBagsByBaggageTypeAsync(Guid flightId, BaggageTypeEnum baggageType)
    {
        return _GetBagsWithCriteria(
            flightId,
            id => BaggageCriteria.GetBagsByBaggageType(id, baggageType),
            $"No {baggageType} bags found for this flight.");
    }

    /// <inheritdoc/>
    public Task<Result> GetInactiveBagsAsync(Guid flightId)
    {
        return _GetBagsWithCriteria(
            flightId,
            BaggageCriteria.GetInactiveBags,
            "No inactive bags found for this flight.");
    }

    /// <inheritdoc/>
    public Task<Result> GetBagsWithOnwardConnectionsAsync(Guid flightId)
    {
        return _GetBagsWithCriteria(
            flightId,
            BaggageCriteria.GetBagsWithOnwardConnections,
            "No bags found with onward connections for this flight.");
    }
    
    /// <summary>
    /// Retrieves baggage for a flight based on specified criteria.
    /// </summary>
    private async Task<Result> _GetBagsWithCriteria(Guid flightId,
        Func<Guid, Expression<Func<Baggage, bool>>> criteriaFunc,
        string emptyMessage)
    {
        if (await _flightQuery.ValidateFlightExistsAsync(flightId) is ErrorResult errorResult)
        {
            return errorResult;
        }

        return await _HandleCollectionRequestAsync<IReadOnlyList<Baggage>, Baggage>(
            () => _baggageRepository.GetAllBaggageByCriteriaAsync(criteriaFunc(flightId)),
            emptyMessage,
            expectedIds: null,
            treatEmptyCollectionAsNotFound: false);
    }
    
    /// <inheritdoc/>
    protected override HashSet<Guid> ExtractIdsFromCollection<T>(IEnumerable<T> collection)
    {
        return collection.OfType<Baggage>().Select(b => b.Id).ToHashSet();
    }
}
