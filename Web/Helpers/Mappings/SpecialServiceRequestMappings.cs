using AutoMapper;
using Core.PassengerContext.SpecialServiceRequests.Dtos;
using Core.PassengerContext.SpecialServiceRequests.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for special service request entities and DTOs using AutoMapper.
/// </summary>
public class SpecialServiceRequestMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpecialServiceRequestMappings"/> class
    /// and configures the mappings for special service request entities.
    /// </summary>
    public SpecialServiceRequestMappings()
    {
        CreateMap<SpecialServiceRequest, SpecialServiceRequestDto>()
            .ForMember(dest => dest.SSRCode, opt => opt.MapFrom(src => src.SSRCodeId))
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight.ScheduledFlightId));
    }
}