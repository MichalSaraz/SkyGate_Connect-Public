namespace Core.BaggageContext.Enums;

/// <summary>
/// Represents special categories of baggage requiring specific handling procedures.
/// </summary>
public enum SpecialBagEnum
{
    /// <summary>
    /// A collapsible baby stroller or buggy.
    /// </summary>
    Buggy,
    
    /// <summary>
    /// A child car seat.
    /// </summary>
    CarSeat,
    
    /// <summary>
    /// A firearm requiring secure handling and documentation.
    /// </summary>
    Firearm,
    
    /// <summary>
    /// Animals traveling in the hold (AVIH - Animal in Hold).
    /// </summary>
    AVIH,
    
    /// <summary>
    /// Manual wheelchair (WCMP - Wheelchair Manual Power).
    /// </summary>
    WCMP,
    
    /// <summary>
    /// Dry-cell battery-powered wheelchair (WCBD - Wheelchair Battery Dry).
    /// </summary>
    WCBD,
    
    /// <summary>
    /// Wet-cell battery-powered wheelchair (WCBW - Wheelchair Battery Wet).
    /// </summary>
    WCBW,
    
    /// <summary>
    /// Lithium battery-powered wheelchair (WCLB - Wheelchair Lithium Battery).
    /// </summary>
    WCLB
}