using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Comments.Entities;

namespace Core.FlightContext.JoinClasses.Entities;

/// <summary>
/// Represents the association between a flight and a comment, including details
/// such as the comment, flight, and their respective identifiers.
/// </summary>
public class FlightComment
{
    /// <summary>
    /// Gets the comment associated with the flight.
    /// </summary>
    public Comment Comment { get; }

    /// <summary>
    /// Gets the unique identifier of the comment.
    /// </summary>
    public Guid CommentId { get; private set; }

    /// <summary>
    /// Gets or sets the flight associated with the comment.
    /// </summary>
    public Flight Flight { get; set; }

    /// <summary>
    /// Gets the unique identifier of the flight.
    /// </summary>
    public Guid FlightId { get; private set; }

    public FlightComment(Guid commentId, Guid flightId)
    {
        CommentId = commentId;
        FlightId = flightId;
    }
}