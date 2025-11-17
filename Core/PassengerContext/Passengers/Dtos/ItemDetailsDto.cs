namespace Core.PassengerContext.Passengers.Dtos;

/// <summary>
/// Represents detailed information about an item, including its weight.
/// Inherits from <see cref="PassengerOrItemOverviewDto"/>.
/// </summary>
public class ItemDetailsDto : PassengerOrItemOverviewDto
{
    /// <summary>
    /// Gets the weight of the item in kilograms. This property is optional.
    /// </summary>
    public int? Weight { get; init; }
}