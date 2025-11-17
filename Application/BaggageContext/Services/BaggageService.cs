using Application.ActionHistoryContext.Interfaces;
using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Application.BaggageContext.Logging;
using Application.MappingContext.Interfaces;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.BaggageContext.Interfaces;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.JoinClasses.Entities;
using Core.PassengerContext.JoinClasses.Entities;
using Core.PassengerContext.Passengers.Entities;
using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Services;

/// <inheritdoc cref="IBaggageService"/>
public class BaggageService : IBaggageService
{
    private readonly IBaggageRepository _baggageRepository;
    private readonly IActionHistoryService _actionHistoryService;
    private readonly IMappingService _mappingService;
    private readonly ILogger<BaggageService> _logger;
    
    public BaggageService(
        IBaggageRepository baggageRepository,
        IActionHistoryService actionHistoryService,
        IMappingService mappingService,
        ILogger<BaggageService> logger)
    {
        _baggageRepository = baggageRepository;
        _actionHistoryService = actionHistoryService;
        _mappingService = mappingService;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Baggage> CreateBaggage(CreateBaggageCommand command, Passenger passenger, Flight selectedFlight)
    {
        var newBaggage = new Baggage(passenger.Id, command.FinalDestination, command.Weight)
        {
            SpecialBag = command.SpecialBagType.HasValue
                ? new SpecialBag(command.SpecialBagType.Value, command.Description)
                : null
        };

        _logger.BaggageCreated(passenger.Id, selectedFlight.Id);
        
        switch (command.TagType)
        {
            case TagTypeEnum.System when command.BaggageType == BaggageTypeEnum.Transfer:
            case TagTypeEnum.Manual when !string.IsNullOrEmpty(command.TagNumber):
                newBaggage.BaggageTag = new BaggageTag(command.TagNumber);
                
                _logger.BaggageTagAssigned(command.TagNumber);
                break;
            
            case TagTypeEnum.System:
                var number = await _baggageRepository.GetNextSequenceValueAsync("BaggageTagsSequence");
                newBaggage.BaggageTag = new BaggageTag(selectedFlight.Airline, number);
                
                _logger.BaggageTagGenerated(selectedFlight.Airline.CarrierCode, number);
                break;
        }

        _AddFlightsToBaggage(newBaggage, command, passenger.Flights, selectedFlight);
        
        return newBaggage;
    }
    
    /// <inheritdoc />
    public Baggage ModifyBaggage(EditBaggageCommand command, Baggage baggage, Guid flightId)
    {
        _actionHistoryService.CreateHistoryContext(
            _mappingService.MapToDto<Baggage, BaggageOverviewDto>(baggage, opt => opt.Items["FlightId"] = flightId),
            command.BaggageId);
    
        baggage.Weight = command.Weight;

        if (command.SpecialBagType.HasValue)
        {
            if (baggage.SpecialBag == null)
            {
                baggage.SpecialBag = new SpecialBag(command.SpecialBagType.Value, command.Description);
                
                _logger.SpecialBagAdded(command.SpecialBagType.Value, baggage.Id);
            }
            else
            {
                baggage.SpecialBag.SpecialBagType = command.SpecialBagType.Value;
                baggage.SpecialBag.SpecialBagDescription = command.Description;
                
                _logger.SpecialBagUpdated(baggage.Id);
            }
        }
        else if (!command.SpecialBagType.HasValue && baggage.SpecialBag != null)
        {
            baggage.SpecialBag = null;
            
            _logger.SpecialBagRemoved(baggage.Id);
        }

        return baggage;
    }

    /// <summary>
    /// Adds flights to the baggage based on the passenger's flight ordering relative to the selected flight.
    /// The method creates FlightBaggage entries for each later connection and stops adding
    /// when the final destination specified in the command is reached.
    /// </summary>
    private void _AddFlightsToBaggage(Baggage baggage, CreateBaggageCommand command, 
        IEnumerable<PassengerFlight> passengerFlights, Flight selectedFlight)
    {
        var orderedFlights = passengerFlights
            .Where(pf => pf.Flight != null && pf.Flight.DepartureDateTime >= selectedFlight.DepartureDateTime)
            .OrderBy(pf => pf.Flight.DepartureDateTime)
            .ToList();

        for (int i = 0; i < orderedFlights.Count; i++)
        {
            var connectingFlight = orderedFlights[i];
            
            var baggageType =
                (i == 0 && command.BaggageType == BaggageTypeEnum.Local) 
                    ? BaggageTypeEnum.Local 
                    : BaggageTypeEnum.Transfer;

            var flightBaggage = new FlightBaggage(connectingFlight.Flight.Id, baggage.Id, baggageType);
            baggage.Flights.Add(flightBaggage);
            
            _logger.FlightBaggageCreated(baggage.Id, connectingFlight.Flight.Id, baggageType);

            if (connectingFlight.Flight.DestinationToId == command.FinalDestination)
            {
                return;
            }
        }
    }
}