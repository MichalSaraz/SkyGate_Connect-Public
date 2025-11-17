namespace Core.ActionHistoryContext.Enums;

/// <summary>
/// Represents the types of actions that can be tracked in the system.
/// </summary>
public enum ActionTypeEnum
{
    /// <summary>
    /// Indicates that an entity was created.
    /// </summary>
    Created,

    /// <summary>
    /// Indicates that an entity was updated.
    /// </summary>
    Updated,

    /// <summary>
    /// Indicates that an entity was deleted.
    /// </summary>
    Deleted
}