namespace Core.PassengerContext.SpecialServiceRequests.Dtos;

/// <summary>
/// Represents a special service request (SSR) associated with a passenger and flight.
/// </summary>
public class SpecialServiceRequestDto
{
    /// <summary>
    /// Gets the SSR code that identifies the type of special service requested.
    /// </summary>
    public string SSRCode { get; init; }

    /// <summary>
    /// Gets the unique identifier of the passenger associated with the request.
    /// </summary>
    public Guid PassengerId { get; init; }

    /// <summary>
    /// Gets the unique identifier of the flight associated with the request.
    /// </summary>
    public Guid FlightId { get; init; }

    /// <summary>
    /// Gets or sets the flight number associated with the request.
    /// </summary>
    public string FlightNumber { get; set; }

    /// <summary>
    /// Gets any additional free-text information related to the request.
    /// </summary>
    public string FreeText { get; init; }
}