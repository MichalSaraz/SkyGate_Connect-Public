using System.ComponentModel.DataAnnotations;
using Core.FlightContext.JoinClasses.Entities;
using Core.PassengerContext.Comments.Enums;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Comments.Entities;

/// <summary>
/// Represents a comment associated with a passenger or item in the booking context.
/// </summary>
public class Comment
{
    /// <summary>
    /// Gets the unique identifier of the comment.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the passenger or item associated with the comment.
    /// </summary>
    public BasePassengerOrItem PassengerOrItem { get; }

    /// <summary>
    /// Gets the unique identifier of the passenger or item associated with the comment.
    /// </summary>
    public Guid PassengerOrItemId { get; private set; }

    /// <summary>
    /// Gets the predefined comment details, if applicable.
    /// </summary>
    public PredefinedComment PredefinedComment { get; }

    /// <summary>
    /// Gets the identifier of the predefined comment, if applicable.
    /// </summary>
    public PredefinedCommentEnum? PredefinedCommentId { get; private set; }

    /// <summary>
    /// Gets the text of the comment. The text is required and has a maximum length of 150 characters.
    /// </summary>
    [Required]
    [MaxLength(150)]
    public string Text { get; private set; }

    /// <summary>
    /// Gets the type of the comment (e.g., gate, check-in).
    /// </summary>
    public CommentTypeEnum CommentType { get; private set; }

    /// <summary>
    /// Gets the list of flights linked to this comment.
    /// </summary>
    public List<FlightComment> LinkedToFlights { get; private set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Comment"/> class for adding a custom comment.
    /// </summary>
    public Comment(Guid passengerOrItemId, CommentTypeEnum commentType, string text)
    {
        Id = Guid.NewGuid();
        PassengerOrItemId = passengerOrItemId;
        CommentType = commentType;
        Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Comment"/> class for adding a predefined comment.
    /// </summary>
    public Comment(Guid passengerOrItemId, PredefinedCommentEnum predefinedCommentId, string text,
        CommentTypeEnum commentType = CommentTypeEnum.Gate)
    {
        Id = Guid.NewGuid();
        PassengerOrItemId = passengerOrItemId;
        PredefinedCommentId = predefinedCommentId;
        Text = text;
        CommentType = commentType;
    }
}