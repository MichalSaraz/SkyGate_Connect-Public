using AutoMapper;
using Core.SeatContext.Dtos;
using Core.SeatContext.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for seat-related entities and DTOs using AutoMapper.
/// </summary>
public class SeatMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SeatMappings"/> class and configures the mappings for seat
    /// entities.
    /// </summary>
    public SeatMappings()
    {
        CreateMap<Seat, SeatDto>()
            .ForMember(dest => dest.PassengerFirstName, opt => opt.MapFrom(src => src.PassengerOrItem.FirstName))
            .ForMember(dest => dest.PassengerLastName, opt => opt.MapFrom(src => src.PassengerOrItem.LastName))
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.ScheduledFlightId));
    }
}