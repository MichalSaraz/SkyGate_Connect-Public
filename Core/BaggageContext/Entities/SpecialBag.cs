using System.ComponentModel.DataAnnotations;
using Core.BaggageContext.Enums;

namespace Core.BaggageContext.Entities;

/// <summary>
/// Represents a special type of baggage with additional details.
/// </summary>
public class SpecialBag
{
    /// <summary>
    /// Gets or sets the type of the special baggage.
    /// </summary>
    public SpecialBagEnum SpecialBagType { get; set; }

    /// <summary>
    /// Gets or sets the description of the special baggage. The maximum length is 150 characters.
    /// </summary>
    [MaxLength(150)]
    public string SpecialBagDescription { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpecialBag"/> class.
    /// </summary>
    /// <param name="specialBagType">The type of the special baggage.</param>
    /// <param name="specialBagDescription">The description of the special baggage. 
    /// Required for certain types of special baggage.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the description is required for the specified baggage type but is not provided.
    /// </exception>
    public SpecialBag(SpecialBagEnum specialBagType, string specialBagDescription)
    {
        SpecialBagType = specialBagType;

        var descriptionRequiredTypes = new List<SpecialBagEnum>
        {
            SpecialBagEnum.AVIH,
            SpecialBagEnum.Firearm,
            SpecialBagEnum.WCLB,
            SpecialBagEnum.WCMP,
            SpecialBagEnum.WCBD,
            SpecialBagEnum.WCBW
        };

        if (descriptionRequiredTypes.Contains(specialBagType) && string.IsNullOrEmpty(specialBagDescription))
        {
            throw new ArgumentException("Description is required");
        }

        SpecialBagDescription = specialBagDescription;
    }
}