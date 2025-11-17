using Core.ActionHistoryContext.Entities;

namespace Core.ActionHistoryContext.Interfaces;

/// <summary>
/// Defines the contract for logging <see cref="ActionHistoryDocument{T}"/> entries that record actions performed on
/// entities.
/// </summary>
public interface IActionHistoryRepository
{
    /// <summary>
    /// Asynchronously logs an <see cref="ActionHistoryDocument{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the entity being tracked in the action history document.</typeparam>
    /// <param name="document">The action history document to log.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task LogAsync<T>(ActionHistoryDocument<T> document);
}