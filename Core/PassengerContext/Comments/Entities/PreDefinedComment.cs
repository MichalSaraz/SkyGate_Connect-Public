using Core.PassengerContext.Comments.Enums;

namespace Core.PassengerContext.Comments.Entities;

/// <summary>
/// Represents a predefined comment that can be associated with a booking.
/// </summary>
public class PredefinedComment
{
    /// <summary>
    /// Gets the unique identifier of the predefined comment.
    /// </summary>
    public PredefinedCommentEnum Id { get; private set; }

    /// <summary>
    /// Gets the text of the predefined comment.
    /// </summary>
    public string Text { get; private set; }

    public PredefinedComment(PredefinedCommentEnum id, string text)
    {
        Id = id;
        Text = text;
    }
}