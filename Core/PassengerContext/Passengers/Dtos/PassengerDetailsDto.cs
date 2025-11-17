using Core.BaggageContext.Dtos;
using Core.PassengerContext.Comments.Dtos;
using Core.PassengerContext.SpecialServiceRequests.Dtos;
using Core.PassengerContext.TravelDocuments.Dtos;

namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents detailed information about a passenger, including baggage allowance, 
/// priority boarding, frequent flyer number, associated infant, travel documents, 
/// checked baggage, comments, and special service requests.
/// Inherits from <see cref="PassengerOrItemOverviewDto"/>.
/// </summary>
public class PassengerDetailsDto : PassengerOrItemOverviewDto
{
    /// <summary>
    /// Gets the baggage allowance for the passenger in kilograms.
    /// </summary>
    public int BaggageAllowance { get; init; }

    /// <summary>
    /// Gets a value indicating whether the passenger has priority boarding.
    /// </summary>
    public bool PriorityBoarding { get; init; }

    /// <summary>
    /// Gets the frequent flyer number associated with the passenger.
    /// </summary>
    public string FrequentFlyerNumber { get; init; }

    /// <summary>
    /// Gets the overview details of the infant associated with the passenger, if any.
    /// </summary>
    public InfantOverviewDto Infant { get; init; }

    /// <summary>
    /// Gets the list of travel documents associated with the passenger.
    /// </summary>
    public List<TravelDocumentDto> TravelDocuments { get; init; } = new();

    /// <summary>
    /// Gets the list of checked baggage associated with the passenger.
    /// </summary>
    public List<BaggageOverviewDto> PassengerCheckedBags { get; init; } = new();

    /// <summary>
    /// Gets the list of comments associated with the passenger.
    /// </summary>
    public List<CommentDto> Comments { get; init; } = new();

    /// <summary>
    /// Gets or sets the list of special service requests associated with the passenger.
    /// </summary>
    public List<SpecialServiceRequestDto> SpecialServiceRequests { get; set; } = new();
}