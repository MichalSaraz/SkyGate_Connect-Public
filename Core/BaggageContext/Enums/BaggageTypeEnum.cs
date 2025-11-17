namespace Core.BaggageContext.Enums;

/// <summary>
/// Classifies baggage by the origin of handling.
/// </summary>
public enum BaggageTypeEnum
{
    /// <summary>
    /// Baggage checked in at this airport.
    /// </summary>
    Local,

    /// <summary>
    /// Baggage transferred from another flight.
    /// </summary>
    Transfer
}