using AutoMapper;
using Core.PassengerContext.TravelDocuments.Dtos;
using Core.PassengerContext.TravelDocuments.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for travel document entities and DTOs using AutoMapper.
/// </summary>
public class TravelDocumentMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TravelDocumentMappings"/> class
    /// and configures the mappings for travel document entities.
    /// </summary>
    public TravelDocumentMappings()
    {
        CreateMap<TravelDocument, TravelDocumentDto>()
            .ForMember(dest => dest.CountryOfIssue, opt => opt.MapFrom(src => src.CountryOfIssueId))
            .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.NationalityId));
    }
}