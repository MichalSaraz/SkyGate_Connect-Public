using Core.PassengerContext.SpecialServiceRequests.Dtos;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents a response DTO containing information about an infant and their associated special service requests.
/// </summary>
public class InfantResponseDto
{
    /// <summary>
    /// Gets the overview details of the infant.
    /// </summary>
    public InfantOverviewDto Infant { get; init; } 

    /// <summary>
    /// Gets the list of special service requests associated with the infant.
    /// </summary>
    public List<SpecialServiceRequestDto> SpecialServiceRequests { get; init; }
}