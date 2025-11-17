using Core.ActionHistoryContext.Entities;

namespace Core.ActionHistoryContext.Interfaces;

/// <summary>
/// Defines the contract for <see cref="ActionHistoryScope{T}"/> for tracking action history.
/// </summary>
public interface IActionHistoryScope
{
    /// <summary>
    /// Gets the username of the user who made the changes.
    /// </summary>
    string UserName { get; }

    /// <summary>
    /// Gets the unique identifier of the entity being tracked.
    /// </summary>
    Guid PassengerOrItemId { get; }
}