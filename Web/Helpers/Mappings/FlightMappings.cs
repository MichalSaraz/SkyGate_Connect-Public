using AutoMapper;
using Core.FlightContext.Flights.Dtos;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.SeatContext.Enums;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for flight-related entities and DTOs using AutoMapper.
/// </summary>
public class FlightMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FlightMappings"/> class and configures the mappings for flight
    /// entities.
    /// </summary>
    public FlightMappings()
    {
        // BaseFlight mappings
        CreateMap<BaseFlight, FlightOverviewDto>();
            
        CreateMap<BaseFlight, FlightDetailsDto>();

        CreateMap<BaseFlight, FlightConnectionsDto>()
            .IncludeBase<BaseFlight, FlightOverviewDto>()
            .Include<Flight, FlightConnectionsDto>()
            .Include<OtherFlight, FlightConnectionsDto>();
            
        // Flight mappings
        CreateMap<Flight, FlightOverviewDto>()
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.ScheduledFlightId))
            .ForMember(dest => dest.DestinationFrom, opt => opt.MapFrom(src => src.DestinationFromId))
            .ForMember(dest => dest.DestinationTo, opt => opt.MapFrom(src => src.DestinationToId));

        CreateMap<Flight, FlightDetailsDto>()
            .IncludeBase<Flight, FlightOverviewDto>()
            .ForMember(dest => dest.FlightDuration,
                opt => opt.MapFrom(src =>
                    src.ScheduledFlight.FlightDuration
                        .FirstOrDefault(kvp => kvp.Key == src.DepartureDateTime.DayOfWeek)
                        .Value))
            .ForMember(dest => dest.CodeShare, opt => opt.MapFrom(src => src.ScheduledFlight.Codeshare))
            .ForMember(dest => dest.ArrivalAirportName, opt => opt.MapFrom(src => src.DestinationTo.AirportName))
            .ForMember(dest => dest.AircraftRegistration, opt => opt.MapFrom(src => src.AircraftId))
            .ForMember(dest => dest.AircraftType, opt => opt.MapFrom(src => src.Aircraft.AircraftTypeId))
            .ForMember(dest => dest.TotalBookedInfants,
                opt => opt.MapFrom(src =>
                    src.ListOfBookedPassengers.Count(pf => pf.PassengerOrItem is Infant)))
            .ForMember(dest => dest.TotalCheckedInInfants,
                opt => opt.MapFrom(src => src.ListOfBookedPassengers.Count(pf =>
                    pf.PassengerOrItem is Infant &&
                    pf.AcceptanceStatus == AcceptanceStatusEnum.Accepted)))
            .ForMember(dest => dest.BookedPassengers,
                opt => opt.MapFrom(src =>
                    src.ListOfBookedPassengers.GroupBy(pf => pf.FlightClass)
                        .ToDictionary(g => g.Key, g => g.Count())))
            .ForMember(dest => dest.StandbyPassengers,
                opt => opt.MapFrom(src =>
                    src.ListOfBookedPassengers.GroupBy(pf => pf.FlightClass)
                        .ToDictionary(g => g.Key,
                            g => g.Count(pf => pf.AcceptanceStatus == AcceptanceStatusEnum.Standby))))
            .ForMember(dest => dest.CheckedInPassengers,
                opt => opt.MapFrom(src =>
                    src.ListOfBookedPassengers.GroupBy(pf => pf.FlightClass)
                        .ToDictionary(g => g.Key,
                            g => g.Count(pf => pf.AcceptanceStatus == AcceptanceStatusEnum.Accepted))))
            .ForMember(dest => dest.AircraftConfiguration,
                opt => opt.MapFrom(src =>
                    src.Seats.GroupBy(s => s.FlightClass).ToDictionary(g => g.Key, g => g.Count())))
            .ForMember(dest => dest.CabinCapacity,
                opt => opt.MapFrom(src =>
                    src.Seats.GroupBy(s => s.FlightClass)
                        .ToDictionary(g => g.Key, g => g.Count(c => c.SeatStatus != SeatStatusEnum.Inop))))
            .ForMember(dest => dest.AvailableSeats,
                opt => opt.MapFrom(src =>
                    src.Seats.GroupBy(s => s.FlightClass)
                        .ToDictionary(g => g.Key, g => g.Count(c => c.SeatStatus == SeatStatusEnum.Empty))));

        CreateMap<Flight, FlightConnectionsDto>()
            .IncludeBase<Flight, FlightOverviewDto>();

        // OtherFlight mappings
        CreateMap<OtherFlight, FlightConnectionsDto>()
            .IncludeBase<OtherFlight, FlightOverviewDto>();
            
        CreateMap<OtherFlight, FlightOverviewDto>()
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber))
            .ForMember(dest => dest.DestinationFrom, opt => opt.MapFrom(src => src.DestinationFromId))
            .ForMember(dest => dest.DestinationTo, opt => opt.MapFrom(src => src.DestinationToId));
    }
}