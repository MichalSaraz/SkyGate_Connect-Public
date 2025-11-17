using AutoMapper;
using Core.PassengerContext.Passengers.Dtos;
using Core.PassengerContext.Passengers.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for base passenger or item entities and DTOs using AutoMapper.
/// </summary>
public class BasePassengerOrItemMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BasePassengerOrItemMappings"/> class 
    /// and configures the mappings for base passenger or item entities.
    /// </summary>
    public BasePassengerOrItemMappings()
    {
        // BasePassengerOrItem mappings
        CreateMap<BasePassengerOrItem, BasePassengerOrItemDto>()
            .ForMember(dest => dest.SeatNumberOnCurrentFlight,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.AssignedSeats?.FirstOrDefault(s => s.FlightId == (Guid)context.Items["FlightId"])
                        ?.SeatNumber))
            .ForMember(dest => dest.PNR, opt => opt.MapFrom(src => src.BookingDetails.PNRId))
            .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src =>
                    src is Passenger ? "Passenger" :
                    src is ExtraSeat ? "ExtraSeat" :
                    src is CabinBaggageRequiringSeat ? "CabinBaggageRequiringSeat" :
                    src is Infant ? "Infant" : null));

        CreateMap<BasePassengerOrItem, PassengerOrItemOverviewDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>()
            .ForMember(dest => dest.CurrentFlight,
                opt => opt.MapFrom((src, _, _, context) => src.Flights?.FirstOrDefault(pf =>
                    pf.Flight?.DepartureDateTime == (DateTime)context.Items["DepartureDateTime"])))
            .ForMember(dest => dest.SeatOnCurrentFlightDetails, opt => opt.MapFrom(src => src.AssignedSeats))
            .ForMember(dest => dest.SeatOnCurrentFlightDetails,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.AssignedSeats?.FirstOrDefault(s => s.FlightId == (Guid)context.Items["FlightId"])))
            .ForMember(dest => dest.ConnectingFlights,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.Flights.Where(pf =>
                            pf.Flight?.DepartureDateTime > (DateTime)context.Items["DepartureDateTime"])
                        .OrderBy(pf => pf.Flight?.DepartureDateTime)))
            .ForMember(dest => dest.InboundFlights,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.Flights?.Where(pf =>
                            pf.Flight?.DepartureDateTime < (DateTime)context.Items["DepartureDateTime"])
                        .OrderBy(pf => pf.Flight?.DepartureDateTime)))
            .ForMember(dest => dest.OtherFlightsSeats,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.AssignedSeats?.Where(s => s.FlightId != (Guid)context.Items["FlightId"])));

        // Passenger mappings
        CreateMap<Passenger, BasePassengerOrItemDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();

        CreateMap<Passenger, PassengerOrItemOverviewDto>()
            .IncludeBase<BasePassengerOrItem, PassengerOrItemOverviewDto>()
            .ForMember(dest => dest.NumberOfCheckedBags, opt => opt.MapFrom(src => src.PassengerCheckedBags.Count));

        CreateMap<Passenger, PassengerDetailsDto>()
            .IncludeBase<Passenger, PassengerOrItemOverviewDto>()
            .ForMember(dest => dest.FrequentFlyerNumber,
                opt => opt.MapFrom(src => src.FrequentFlyerCard.FrequentFlyerNumber));

        // ExtraSeat mappings
        CreateMap<ExtraSeat, BasePassengerOrItemDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();

        CreateMap<ExtraSeat, PassengerOrItemOverviewDto>()
            .IncludeBase<BasePassengerOrItem, PassengerOrItemOverviewDto>();

        CreateMap<ExtraSeat, ItemDetailsDto>()
            .IncludeBase<ExtraSeat, PassengerOrItemOverviewDto>();


        // CabinBaggageRequiringSeat mappings
        CreateMap<CabinBaggageRequiringSeat, BasePassengerOrItemDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();

        CreateMap<CabinBaggageRequiringSeat, PassengerOrItemOverviewDto>()
            .IncludeBase<BasePassengerOrItem, PassengerOrItemOverviewDto>();

        CreateMap<CabinBaggageRequiringSeat, ItemDetailsDto>()
            .IncludeBase<CabinBaggageRequiringSeat, PassengerOrItemOverviewDto>();


        // Infant mapping
        CreateMap<Infant, BasePassengerOrItemDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();

        CreateMap<Infant, InfantOverviewDto>()
            .IncludeBase<Infant, BasePassengerOrItemDto>()
            .ForMember(dest => dest.SeatNumberOnCurrentFlight, opt => opt.Ignore())
            .ForMember(dest => dest.CurrentFlight,
                opt => opt.MapFrom((src, _, _, context) => src.Flights?.FirstOrDefault(pf =>
                    pf.Flight?.DepartureDateTime == (DateTime)context.Items["DepartureDateTime"])));

        CreateMap<Infant, InfantDetailsDto>()
            .IncludeBase<Infant, InfantOverviewDto>()
            .ForMember(dest => dest.ConnectingFlights,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.Flights?.Where(pf =>
                            pf.Flight?.DepartureDateTime > (DateTime)context.Items["DepartureDateTime"])
                        .OrderBy(pf => pf.Flight?.DepartureDateTime)))
            .ForMember(dest => dest.InboundFlights,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.Flights?.Where(pf =>
                            pf.Flight?.DepartureDateTime < (DateTime)context.Items["DepartureDateTime"])
                        .OrderBy(pf => pf.Flight?.DepartureDateTime)));
    }
}