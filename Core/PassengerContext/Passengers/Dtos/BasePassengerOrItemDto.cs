using Newtonsoft.Json;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents the base DTO for a passenger or item, containing common properties
/// such as identifiers, personal details, and flight-related information.
/// </summary>
public class BasePassengerOrItemDto
{
    /// <summary>
    /// Gets the unique identifier of the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the first name of the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public string FirstName { get; init; }

    /// <summary>
    /// Gets the last name of the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public string LastName { get; init; }

    /// <summary>
    /// Gets the gender of the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public string Gender { get; init; }
        
    /// <summary>
    /// Gets the Passenger Name Record (PNR) associated with the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public string PNR { get; init; }
        
    /// <summary>
    /// Gets the seat number of the passenger on the current flight.
    /// This property can be overridden in derived classes.
    /// </summary>
    [JsonProperty(Order = -3)]
    public virtual string SeatNumberOnCurrentFlight { get; init; }
        
    /// <summary>
    /// Gets the type of the passenger or item.
    /// </summary>
    [JsonProperty(Order = -3)]
    public string Type { get; init; }
}