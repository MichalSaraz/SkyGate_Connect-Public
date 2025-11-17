using Application.MappingContext.Interfaces;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Dtos;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;

namespace Application.MappingContext.Services;

/// <inheritdoc cref="IPassengerOrItemDtoMappingService"/>
public class PassengerOrItemDtoMappingService : IPassengerOrItemDtoMappingService
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly IMappingService _mappingService;

    public PassengerOrItemDtoMappingService(IMappingService mappingService,
        IPassengerRepository passengerRepository)
    {
        _mappingService = mappingService;
        _passengerRepository = passengerRepository;
    }

    /// <inheritdoc/>
    public BasePassengerOrItemDto? MapSinglePassengerOrItemToDto(BasePassengerOrItem item, BaseFlight flight,
        bool displayDetails = true)
    {
        return item switch
        {
            Passenger passenger => (displayDetails)
                ? _mappingService.MapToDto<Passenger, PassengerDetailsDto>(passenger, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                })
                : _mappingService.MapToDto<Passenger, PassengerOrItemOverviewDto>(passenger, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                }),
            Infant infant => (displayDetails)
                ? _mappingService.MapToDto<Infant, InfantDetailsDto>(infant, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                })
                : _mappingService.MapToDto<Infant, InfantOverviewDto>(infant, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                }),
            CabinBaggageRequiringSeat or ExtraSeat when displayDetails =>
                _mappingService.MapToDto<BasePassengerOrItem, ItemDetailsDto>(item, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                }),
            CabinBaggageRequiringSeat or ExtraSeat =>
                _mappingService.MapToDto<BasePassengerOrItem, PassengerOrItemOverviewDto>(item, opt =>
                {
                    opt.Items["DepartureDateTime"] = flight.DepartureDateTime;
                    opt.Items["FlightId"] = flight.Id;
                }),
            _ => null
        };
    }

    /// <inheritdoc/>
    public List<BasePassengerOrItemDto> MapPassengersOrItemsToDto(IEnumerable<BasePassengerOrItem> passengerOrItems,
        BaseFlight flight, bool displayDetails = true)
    {
        return passengerOrItems
            .Select(passengerOrItem => MapSinglePassengerOrItemToDto(passengerOrItem, flight, displayDetails))
            .OfType<BasePassengerOrItemDto>()
            .ToList();
    }
    
    /// <inheritdoc/>
    public async Task<PassengerDetailsDto> MapToDtoAsync(Passenger noRecPassenger, Flight selectedFlight, Guid flightId)
    {
        var updatedPassengerForDto = 
            await _passengerRepository.GetPassengerDetailsByFlightAndIdAsync(flightId, noRecPassenger.Id, false);

        return _mappingService.MapToDto<Passenger, PassengerDetailsDto>(updatedPassengerForDto, opt =>
        {
            opt.Items["DepartureDateTime"] = selectedFlight.DepartureDateTime;
            opt.Items["FlightId"] = flightId;
        });
    }
    
    /// <inheritdoc/>
    public InfantResponseDto MapInfantToResponseDto(Passenger passenger, BaseFlight flight)
    {
        var passengerDto = MapSinglePassengerOrItemToDto(passenger, flight) as PassengerDetailsDto;

        return new InfantResponseDto
        {
            Infant = passengerDto?.Infant,
            SpecialServiceRequests = passengerDto?.SpecialServiceRequests
        };
    }
}