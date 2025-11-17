using Application.BaggageContext.Commands;
using AutoMapper;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Web.Api.BaggageManagement.Models;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for baggage-related entities and DTOs using AutoMapper.
/// </summary>
public class BaggageMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaggageMappings"/> class and configures the mappings.
    /// </summary>
    public BaggageMappings()
    {
        CreateMap<Baggage, BaggageOverviewDto>()
            .ForMember(dest => dest.TagNumber, opt => opt.MapFrom(src => src.BaggageTag.TagNumber))
            .ForMember(dest => dest.FinalDestination, opt => opt.MapFrom(src => src.DestinationId))
            .ForMember(dest => dest.PassengerFirstName, opt => opt.MapFrom(src => src.Passenger.FirstName))
            .ForMember(dest => dest.PassengerLastName, opt => opt.MapFrom(src => src.Passenger.LastName))
            .ForMember(dest => dest.SpecialBagType, opt => opt.MapFrom(src => src.SpecialBag.SpecialBagType))
            .ForMember(dest => dest.SpecialBagDescription,
                opt => opt.MapFrom(src => src.SpecialBag.SpecialBagDescription))
            .ForMember(dest => dest.BaggageType,
                opt => opt.MapFrom((src, _, _, context) =>
                    src.Flights?.FirstOrDefault(fb => fb.FlightId == (Guid)context.Items["FlightId"])
                        ?.BaggageType));

        CreateMap<Baggage, BaggageDetailsDto>().IncludeBase<Baggage, BaggageOverviewDto>();

        CreateMap<AddBaggageModel, CreateBaggageCommand>();
        CreateMap<EditBaggageModel, EditBaggageCommand>();
    }
}