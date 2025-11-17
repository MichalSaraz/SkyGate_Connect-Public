using Core.ActionHistoryContext.Interfaces;

namespace Core.ActionHistoryContext.Entities;

/// <summary>
/// Represents the context for tracking actions performed on an entity, including the original value, user information,
/// and entity identifiers.
/// </summary>
/// <typeparam name="T">The type of the original value being tracked.</typeparam>
public class ActionHistoryScope<T> : IActionHistoryScope
{
    /// <summary>
    /// Gets the original value of the entity before the action was performed.
    /// </summary>
    public T OriginalValue { get; }

    /// <summary>
    /// Gets the name of the user who performed the action.
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// Gets the identifier of the entity being tracked, if available.
    /// </summary>
    public string EntityId { get; }

    /// <summary>
    /// Gets the unique identifier of the passenger or item associated with the action.
    /// </summary>
    public Guid PassengerOrItemId { get; }

    public ActionHistoryScope(T originalValue, string userName, Guid passengerOrItemId, string entityId = null)
    {
        OriginalValue = originalValue;
        UserName = userName;
        PassengerOrItemId = passengerOrItemId;
        EntityId = entityId;
    }
}
