using AutoMapper;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.JoinClasses.Dtos;
using Core.FlightContext.JoinClasses.Entities;
using Core.PassengerContext.JoinClasses.Dtos;
using Core.PassengerContext.JoinClasses.Entities;
using Core.PassengerContext.Passengers.Dtos;
using Core.PassengerContext.Passengers.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for join classes entities and DTOs using AutoMapper.
/// </summary>
public class JoinClassesMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JoinClassesMappings"/> class
    /// and configures the mappings for join classes entities.
    /// </summary>
    public JoinClassesMappings()
    {
        CreateMap<PassengerFlight, PassengerFlightDto>()
            .ForMember(dest => dest.FlightNumber,
                opt => opt.MapFrom(src =>
                    src.Flight is Flight
                        ? ((Flight)src.Flight).ScheduledFlightId
                        : src.Flight is OtherFlight
                            ? ((OtherFlight)src.Flight).FlightNumber
                            : null))
            .ForMember(dest => dest.DestinationFrom, opt => opt.MapFrom(src => src.Flight.DestinationFromId))
            .ForMember(dest => dest.DestinationTo, opt => opt.MapFrom(src => src.Flight.DestinationToId))
            .ForMember(dest => dest.DepartureDateTime, opt => opt.MapFrom(src => src.Flight.DepartureDateTime))
            .ForMember(dest => dest.ArrivalDateTime, opt => opt.MapFrom(src => src.Flight.ArrivalDateTime));

        CreateMap<FlightBaggage, FlightBaggageDto>()
            .ForMember(dest => dest.Flight, opt => opt.UseDestinationValue());

        CreateMap<FlightComment, FlightCommentDto>()
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.ScheduledFlightId));

        CreateMap<BasePassengerOrItem, PassengerOrItemCommentsDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();

        CreateMap<BasePassengerOrItem, PassengerSpecialServiceRequestsDto>()
            .IncludeBase<BasePassengerOrItem, BasePassengerOrItemDto>();
    }
}