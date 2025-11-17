using Newtonsoft.Json;

namespace Core.BaggageContext.Dtos;

/// <summary>
/// Represents an overview of baggage details.
/// </summary>
public class BaggageOverviewDto : BaggageBaseDto
{
    /// <summary>
    /// Gets the unique identifier of the baggage.
    /// </summary>
    [JsonProperty(Order = -2)]
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the tag number associated with the baggage.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string TagNumber { get; init; }

    /// <summary>
    /// Gets the weight of the baggage in kilograms.
    /// </summary>
    [JsonProperty(Order = -2)]
    public int Weight { get; init; }

    /// <summary>
    /// Gets the final destination of the baggage.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string FinalDestination { get; init; }

    /// <summary>
    /// Gets or sets the first name of the passenger associated with the baggage.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string PassengerFirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the passenger associated with the baggage.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string PassengerLastName { get; set; }

    /// <summary>
    /// Gets the type of special baggage, if applicable.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string SpecialBagType { get; init; }

    /// <summary>
    /// Gets the description of the special baggage, if applicable.
    /// </summary>
    [JsonProperty(Order = -2)]
    public string SpecialBagDescription { get; init; }

    /// <summary>
    /// Gets the type of the baggage (e.g., local, transfer).
    /// </summary>
    [JsonProperty(Order = -2)]
    public string BaggageType { get; init; }
}