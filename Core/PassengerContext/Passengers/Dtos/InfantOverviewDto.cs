using Core.PassengerContext.JoinClasses.Dtos;
using Newtonsoft.Json;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents an overview of an infant, including their seat number, associated adult passenger,
/// and current flight details. Inherits from <see cref="BasePassengerOrItemDto"/>.
/// </summary>
public class InfantOverviewDto : BasePassengerOrItemDto
{
    /// <summary>
    /// Gets the seat number of the infant on the current flight.
    /// This property is ignored during JSON serialization.
    /// </summary>
    [JsonIgnore]
    [JsonProperty(Order = -3)]
    public override string SeatNumberOnCurrentFlight { get; init; }

    /// <summary>
    /// Gets the unique identifier of the adult passenger associated with the infant.
    /// </summary>
    [JsonProperty(Order = -2)]
    public Guid AssociatedAdultPassengerId { get; init; }

    /// <summary>
    /// Gets the details of the infant's current flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public PassengerFlightDto CurrentFlight { get; init; }
}