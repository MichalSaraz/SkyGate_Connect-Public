namespace Core.FlightContext.JoinClasses.Dtos;

/// <summary>
/// Represents a comment associated with a flight.
/// </summary>
public class FlightCommentDto
{
    /// <summary>
    /// Gets the flight number associated with the comment.
    /// </summary>
    public string FlightNumber { get; init; }
}