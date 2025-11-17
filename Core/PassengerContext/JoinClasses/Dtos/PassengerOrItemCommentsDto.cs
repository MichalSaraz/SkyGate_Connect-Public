using Core.PassengerContext.Comments.Dtos;
using Core.PassengerContext.Passengers.Dtos;

namespace Core.PassengerContext.JoinClasses.Dtos;

/// <summary>
/// Represents a DTO that contains comments associated with a passenger or item.
/// Inherits from <see cref="BasePassengerOrItemDto"/>.
/// </summary>
public class PassengerOrItemCommentsDto : BasePassengerOrItemDto
{
    /// <summary>
    /// Gets or sets the list of comments related to the passenger or item.
    /// </summary>
    public List<CommentDto> Comments { get; set; } = new();
}