using System.ComponentModel.DataAnnotations;

namespace Core.PassengerContext.SpecialServiceRequests.Entities;

/// <summary>
/// Represents a Special Service Request (SSR) code, which includes details about the code,
/// its description, and whether free text input is mandatory.
/// </summary>
public class SSRCode
{
    /// <summary>
    /// Gets or sets the unique SSR code.
    /// </summary>
    [Key] 
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the description of the SSR code.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether free text input is mandatory for this SSR code.
    /// </summary>
    public bool IsFreeTextMandatory { get; set; }
}