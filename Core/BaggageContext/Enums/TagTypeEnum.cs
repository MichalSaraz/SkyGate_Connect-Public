namespace Core.BaggageContext.Enums;

/// <summary>
/// Specifies the type of baggage tag based on its origin or handling process.
/// </summary>
public enum TagTypeEnum
{
    /// <summary>
    /// A system-generated tag, typically created automatically by the baggage handling system.
    /// </summary>
    System,

    /// <summary>
    /// A manually created tag, usually issued by an agent or staff member.
    /// </summary>
    Manual
}