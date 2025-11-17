using Core.FlightContext.JoinClasses.Dtos;

namespace Core.PassengerContext.Comments.Dtos;

/// <summary>
/// Represents a comment with associated details, including its type, text,
/// and any linked flights.
/// </summary>
public class CommentDto
{
    /// <summary>
    /// Gets the unique identifier of the comment.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the type of the comment.
    /// </summary>
    public string CommentType { get; init; }

    /// <summary>
    /// Gets the text content of the comment.
    /// </summary>
    public string Text { get; init; }

    /// <summary>
    /// Gets the list of flights linked to this comment.
    /// </summary>
    public List<FlightCommentDto> LinkedToFlights { get; set; } = new();
}