using Core.BaggageContext.Enums;
using Core.FlightContext.ReferenceData.Entities;

namespace Core.BaggageContext.Entities;

/// <summary>
/// Represents a baggage tag used for identifying and categorizing baggage.
/// </summary>
public class BaggageTag
{
    /// <summary>
    /// Gets the unique baggage tag number assigned to the baggage.
    /// </summary>
    public string TagNumber { get; private set; }

    /// <summary>
    /// Gets the airline associated with the baggage tag, if applicable.
    /// </summary>
    public Airline Airline { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the airline associated with the baggage tag, if applicable.
    /// </summary>
    public string AirlineId { get; set; }

    /// <summary>
    /// Gets or sets the leading digit of the baggage tag number, used for categorization.
    /// </summary>
    public int LeadingDigit { get; }

    /// <summary>
    /// Gets or sets the numeric identifier of the baggage tag.
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// Gets the type of the baggage tag indicating its origin (manual or system-generated).
    /// </summary>
    public TagTypeEnum TagType { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaggageTag"/> class with a manually assigned tag number.
    /// </summary>
    /// <param name="tagNumber">The manually assigned tag number.</param>
    public BaggageTag(string tagNumber)
    {
        TagNumber = tagNumber;
        TagType = TagTypeEnum.Manual;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaggageTag"/> class with an airline and a numeric identifier.
    /// </summary>
    /// <param name="airline">The airline associated with the baggage tag.</param>
    /// <param name="number">The numeric identifier for the baggage tag.</param>
    public BaggageTag(Airline airline, int number)
    {
        Airline = airline;
        LeadingDigit = 0;
        Number = number;
        TagNumber = _GetBaggageTagNumber();
        TagType = TagTypeEnum.System;
    }

    /// <summary>
    /// Generates the baggage tag number based on the airline and numeric identifier.
    /// </summary>
    private string _GetBaggageTagNumber()
    {
        string airlinePrefix = Airline?.AirlinePrefix ?? "000";
        string carrierCode = Airline?.CarrierCode ?? "XY";
        string number = Number.ToString("D6");

        return $"{LeadingDigit}{airlinePrefix}-{carrierCode}-{number}";
    }
}