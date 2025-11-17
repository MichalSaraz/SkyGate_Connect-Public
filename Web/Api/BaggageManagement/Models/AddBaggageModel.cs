using System.ComponentModel.DataAnnotations;
using Core.BaggageContext.Enums;

namespace Web.Api.BaggageManagement.Models;

/// <summary>
/// Represents the model for adding baggage, including its properties and validation requirements.
/// </summary>
public class AddBaggageModel
{
    /// <summary>
    /// The type of tag associated with the baggage.
    /// This property is required.
    /// </summary>
    [Required]
    public TagTypeEnum TagType { get; set; }

    /// <summary>
    /// The weight of the baggage in kilograms.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// The type of special baggage, if applicable.
    /// </summary>
    public SpecialBagEnum? SpecialBagType { get; set; }

    /// <summary>
    /// The type of baggage (e.g., Local or Transfer).
    /// Defaults to <see cref="BaggageTypeEnum.Local"/>.
    /// </summary>
    public BaggageTypeEnum BaggageType { get; set; } = BaggageTypeEnum.Local;

    /// <summary>
    /// An optional description of the baggage.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The final destination of the baggage.
    /// This property is required.
    /// </summary>
    [Required]
    public required string FinalDestination { get; set; }

    /// <summary>
    /// The tag number associated with the baggage.
    /// Defaults to an empty string.
    /// </summary>
    public string TagNumber { get; set; } = string.Empty;
}