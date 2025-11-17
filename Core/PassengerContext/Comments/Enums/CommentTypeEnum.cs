namespace Core.PassengerContext.Comments.Enums;

/// <summary>
/// Represents the type of comment associated with a passenger's booking.
/// </summary>
public enum CommentTypeEnum
{
    /// <summary>
    /// Indicates a list-only comment that does not affect processing.
    /// </summary>
    Checkin,

    /// <summary>
    /// Indicates a high-priority comment that must be resolved before proceeding.
    /// </summary>
    Gate
}