using Core.PassengerContext.JoinClasses.Dtos;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents detailed information about an infant, including connecting and inbound flights.
/// Inherits from <see cref="InfantOverviewDto"/>.
/// </summary>
public class InfantDetailsDto : InfantOverviewDto
{
    /// <summary>
    /// Gets the list of connecting flights associated with the infant.
    /// </summary>
    public List<PassengerFlightDto> ConnectingFlights { get; init; }

    /// <summary>
    /// Gets the list of inbound flights associated with the infant.
    /// </summary>
    public List<PassengerFlightDto> InboundFlights { get; init; }
}