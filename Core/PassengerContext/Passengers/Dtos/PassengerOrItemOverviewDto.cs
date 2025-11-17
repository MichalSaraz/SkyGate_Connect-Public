using Core.PassengerContext.JoinClasses.Dtos;
using Core.SeatContext.Dtos;
using Newtonsoft.Json;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents an overview of a passenger or item, including details about checked bags,
/// current flight, seat details, connecting flights, inbound flights, and seats on other flights.
/// Inherits from <see cref="BasePassengerOrItemDto"/>.
/// </summary>
public class PassengerOrItemOverviewDto : BasePassengerOrItemDto
{
    /// <summary>
    /// Gets the number of checked bags associated with the passenger or item.
    /// </summary>
    [JsonProperty(Order = -2)]
    public int NumberOfCheckedBags { get; init; }

    /// <summary>
    /// Gets the details of the current flight associated with the passenger or item.
    /// </summary>
    [JsonProperty(Order = -2)]
    public PassengerFlightDto CurrentFlight { get; init; }

    /// <summary>
    /// Gets the seat details for the passenger or item on the current flight.
    /// </summary>
    [JsonProperty(Order = -2)]
    public SeatDto SeatOnCurrentFlightDetails { get; init; }

    /// <summary>
    /// Gets the list of connecting flights associated with the passenger or item.
    /// </summary>
    [JsonProperty(Order = -2)]
    public List<PassengerFlightDto> ConnectingFlights { get; init; }

    /// <summary>
    /// Gets the list of inbound flights associated with the passenger or item.
    /// </summary>
    [JsonProperty(Order = -2)]
    public List<PassengerFlightDto> InboundFlights { get; init; }

    /// <summary>
    /// Gets the list of seat details for the passenger or item on other flights.
    /// </summary>
    [JsonProperty(Order = -2)]
    public List<SeatDto> OtherFlightsSeats { get; init; }
}