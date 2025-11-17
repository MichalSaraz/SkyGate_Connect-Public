using System.ComponentModel.DataAnnotations;
using Core.BaggageContext.Enums;

namespace Web.Api.BaggageManagement.Models;

/// <summary>
/// Represents the model for editing an existing baggage entry.
/// </summary>
public class EditBaggageModel
{
    /// <summary>
    /// The unique identifier of the baggage to be edited.
    /// This property is required.
    /// </summary>
    [Required]
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