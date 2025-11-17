using Application.ActionHistoryContext.Interfaces;
using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Application.BaggageContext.Logging;
using Application.MappingContext.Interfaces;
using Core.ActionHistoryContext.Enums;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Interfaces;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;
using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Facades;

/// <inheritdoc cref="IBaggageFacade"/>
public class BaggageFacade : IBaggageFacade
{
    private readonly IBaggageService _baggageService;
    private readonly IMappingService _mappingService;
    private readonly IActionHistoryService _actionHistoryService;
    private readonly IBaggageRepository _baggageRepository;
    private readonly ILogger<BaggageFacade> _logger;

    public BaggageFacade(
        IBaggageService baggageService,
        IMappingService mappingService,
        IActionHistoryService actionHistoryService,
        IBaggageRepository baggageRepository,
        ILogger<BaggageFacade> logger)
    {
        _baggageService = baggageService;
        _mappingService = mappingService;
        _actionHistoryService = actionHistoryService;
        _baggageRepository = baggageRepository;
        _logger = logger;
    }
    
    /// <inheritdoc/>
    public async Task<List<BaggageOverviewDto>> AddBaggageAsync(Passenger passenger, Flight flight,
        List<CreateBaggageCommand> commands, Guid flightId, Guid passengerId)
    {
        _logger.AddBaggageStarted(passengerId, flightId, commands.Count);
        var bagList = new List<Baggage>();

        foreach (var command in commands)
        {
            var newBaggage = await _baggageService.CreateBaggage(command, passenger, flight);

            await _baggageRepository.AddAsync(newBaggage);
            bagList.Add(newBaggage);
            
            _logger.AddBaggageAdded(newBaggage.Id);
        }
        
        await _baggageRepository.UpdateAsync(bagList.ToArray());

        var dtoList = _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(bagList, flightId);

        foreach (var dto in dtoList)
        {
            dto.PassengerFirstName = passenger.FirstName;
            dto.PassengerLastName = passenger.LastName;
        }

        await _actionHistoryService.SaveChangeToHistoryAsync(
            dtoList,
            ActionTypeEnum.Created,
            nameof(Baggage),
            passengerId);

        _logger.AddBaggageSuccess(string.Join(",", dtoList.Select(d => d.Id)));
        
        return dtoList;
    }
    
    /// <inheritdoc/>
    public async Task<List<BaggageOverviewDto>> EditBaggageAsync(List<EditBaggageCommand> commands, 
        IReadOnlyList<Baggage> baggageToEdit, Guid flightId, Guid passengerId)
    {
        _logger.EditBaggageStarted(passengerId, flightId, commands.Count);
        var changesToSave = new List<Baggage>();

        foreach (var command in commands)
        {
            var selectedBaggage = baggageToEdit.First(b => b.Id == command.BaggageId);
            var updatedBaggage = _baggageService.ModifyBaggage(command, selectedBaggage, flightId);
            changesToSave.Add(updatedBaggage);
        }

        await _baggageRepository.UpdateAsync(changesToSave.ToArray());

        var updatedBaggageListDto = 
            _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(changesToSave, flightId);

        await _actionHistoryService.SaveChangesToHistoryAsync(
            updatedBaggageListDto,
            ActionTypeEnum.Updated,
            nameof(Baggage),
            passengerId);

        _logger.EditBaggageSuccess(string.Join(",", updatedBaggageListDto.Select(d => d.Id)));
        
        return updatedBaggageListDto;
    }
    
    /// <inheritdoc/>
    public async Task DeleteBaggageAsync(IReadOnlyList<Baggage> baggage, Guid flightId, Guid passengerId)
    {
        _logger.DeleteBaggageStarted(passengerId, flightId, baggage.Count);
        
        var dtoList = _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(baggage, flightId);

        _actionHistoryService.CreateHistoryContexts(dtoList, passengerId);
        await _actionHistoryService.SaveChangesToHistoryAsync<BaggageOverviewDto>(
            null,
            ActionTypeEnum.Deleted,
            nameof(Baggage),
            passengerId);

        await _baggageRepository.DeleteAsync(baggage.ToArray());
        
        _logger.DeleteBaggageSuccess(string.Join(",", baggage.Select(b => b.Id)));
    }
}