using Core.PassengerContext.Passengers.Dtos;
using Core.PassengerContext.SpecialServiceRequests.Dtos;

namespace Core.PassengerContext.JoinClasses.Dtos;

/// <summary>
/// Represents a DTO that contains special service requests associated with a passenger or item.
/// Inherits from <see cref="BasePassengerOrItemDto"/>.
/// </summary>
public class PassengerSpecialServiceRequestsDto : BasePassengerOrItemDto
{
    /// <summary>
    /// Gets or sets the list of special service requests related to the passenger or item.
    /// </summary>
    public List<SpecialServiceRequestDto> SpecialServiceRequests { get; set; } = new();
}