using AutoMapper;
using Core.PassengerContext.Comments.Dtos;
using Core.PassengerContext.Comments.Entities;

namespace Web.Helpers.Mappings;

/// <summary>
/// Defines mappings for comment-related entities and DTOs using AutoMapper.
/// </summary>
public class CommentMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentMappings"/> class
    /// and configures the mappings for comment entities.
    /// </summary>
    public CommentMappings()
    {
        CreateMap<Comment, CommentDto>();
    }
}