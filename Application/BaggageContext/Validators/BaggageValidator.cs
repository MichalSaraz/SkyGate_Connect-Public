using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Application.BaggageContext.Logging;
using Application.FlightContext.Interfaces;
using Application.PassengerContext.Passengers.Interfaces;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.FlightContext.Flights.Entities;
using Core.OperationResults;
using Core.PassengerContext.Passengers.Entities;
using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Validators;

/// <inheritdoc cref="IBaggageValidator"/>
public class BaggageValidator : IBaggageValidator
{
    
    private readonly IFlightQuery _flightQuery;
    private readonly IPassengerQuery _passengerQuery;
    private readonly ICheckinRulesEvaluator _checkinRulesEvaluator;
    private readonly IFlightRulesEvaluator _flightRulesEvaluator;
    private readonly IDestinationQuery _destinationQuery;
    private readonly IBaggageRulesEvaluator _baggageRulesEvaluator;
    private readonly IBaggageQuery  _baggageQuery;
    private readonly ILogger<BaggageValidator> _logger;

    public BaggageValidator(
        IFlightQuery flightQuery,
        IPassengerQuery passengerQuery,
        ICheckinRulesEvaluator checkinRulesEvaluator,
        IFlightRulesEvaluator flightRulesEvaluator,
        IDestinationQuery destinationQuery,
        IBaggageRulesEvaluator baggageRulesEvaluator,
        IBaggageQuery baggageQuery,
        ILogger<BaggageValidator> logger)
    {
        _flightQuery = flightQuery;
        _passengerQuery = passengerQuery;
        _checkinRulesEvaluator = checkinRulesEvaluator;
        _flightRulesEvaluator = flightRulesEvaluator;
        _destinationQuery = destinationQuery;
        _baggageRulesEvaluator = baggageRulesEvaluator;
        _baggageQuery = baggageQuery;
        _logger = logger;
    }
    
    /// <inheritdoc />
    public async Task<Result> ValidateAddBaggage(List<CreateBaggageCommand> commands, Guid passengerId, Guid flightId)
    {
        if (commands.Count == 0) 
        {
            _logger.AddNoDataProvided();
            return Result.Failure(400, "No baggage data provided.");
        }

        if (commands.Any(bm => bm.TagType == TagTypeEnum.Manual && string.IsNullOrEmpty(bm.TagNumber)))
        {
            _logger.AddMissingTagNumber();
            return Result.Failure(400, "All baggage with TagType 'Manual' must have a TagNumber.");
        }

        var passengerResult = await _passengerQuery.RetrievePassengerDetailsByIdAsync(passengerId, false);
        if (!passengerResult.TryGetData<Passenger>(out var passenger))
        {
            return passengerResult;
        }

        var flightResult = await _flightQuery.RetrieveFlightByIdAsync(flightId);
        if (!flightResult.TryGetData<Flight>(out var selectedFlight))
        {
            return flightResult;
        }

        if (!_checkinRulesEvaluator.IsPassengerCheckedIn(passenger, selectedFlight))
        {
            _logger.AddPassengerNotCheckedIn(passengerId);
            return Result.Failure(400, "Passenger must be checked in to add baggage.");
        }
        
        if (!_flightRulesEvaluator.IsFlightOpenForEdits(selectedFlight))
        {
            _logger.AddFlightNotOpenForEdits(flightId);
            return Result.Failure(400,
                $"Cannot add baggage to passenger when flight status is {selectedFlight.FlightStatus}.");
        }
        
        var destinationResult = await _destinationQuery.RetrieveDestinationByCriteriaAsync(
            d => d.IATAAirportCode == commands.First().FinalDestination);
        if (destinationResult.NoDataResponse != null)
        {
            return destinationResult;
        }

        if (!_baggageRulesEvaluator.HasMatchingFinalDestination(commands, passenger))
        {
            _logger.AddFinalDestinationMismatch();
            return Result.Failure(400, "All baggage must have the same final destination.");
        }

        return Result.Success((passenger, selectedFlight));
    }
    
    /// <inheritdoc />
    public async Task<Result> ValidateEditBaggage(List<EditBaggageCommand> commands, Guid passengerId)
    {
        if (commands.Count == 0)
        {
            _logger.EditNoDataProvided();
            return Result.Failure(400, "No baggage data provided.");
        }

        var passengerValidationResult = await _passengerQuery.ValidatePassengerExistsAsync(passengerId);
        if (passengerValidationResult.NoDataResponse != null)
        {
            return passengerValidationResult;
        }

        var requestedIds = commands.Select(c => c.BaggageId).Distinct().ToList();
        var baggageResult = await _baggageQuery.RetrieveAllBaggageByCriteriaAsync(
            b => requestedIds.Contains(b.Id) && b.PassengerId == passengerId, true, requestedIds);

        return !baggageResult.TryGetData<IReadOnlyList<Baggage>>(out var baggageToEdit) 
            ? baggageResult 
            : Result.Success(baggageToEdit);
    }

    /// <inheritdoc />
    public async Task<Result> ValidateDeleteBaggage(List<Guid> baggageIds, Guid passengerId)
    {
        var baggageResult = await _baggageQuery.RetrieveAllBaggageByCriteriaAsync(
            b => baggageIds.Contains(b.Id) && b.PassengerId == passengerId, true, baggageIds);
        
        return !baggageResult.TryGetData<List<Baggage>>(out var baggageList) 
            ? baggageResult 
            : Result.Success(baggageList);
    }
}