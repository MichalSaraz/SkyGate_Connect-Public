using Core.BaggageContext.Enums;

namespace Application.BaggageContext.Commands;

/// <summary>
/// Represents a command to edit an existing baggage entry.
/// </summary>
public class EditBaggageCommand
{
    /// <summary>
    /// The unique identifier of the baggage to be edited.
    /// </summary>
    public Guid BaggageId { get; set; }

    /// <summary>
    /// The updated weight of the baggage in kilograms.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// The updated type of special baggage, if applicable.
    /// </summary>
    public SpecialBagEnum? SpecialBagType { get; set; }

    /// <summary>
    /// An optional updated description of the baggage.
    /// </summary>
    public string? Description { get; set; }
}