namespace Core.Abstractions;

/// <summary>
/// Generic repository contract that defines common CRUD operations for entity types.
/// Implementations are responsible for persisting changes to the underlying data store
/// and may return a representative entity from create/update/delete operations.
/// </summary>
/// <typeparam name="T">The entity type managed by the repository.</typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Adds the specified entities to the repository asynchronously and persists the changes.
    /// </summary>
    /// <param name="entities">One or more entity instances to add to the repository.</param>
    /// <returns>
    /// A <see cref="Task{T}"/> that resolves to a representative <typeparamref name="T"/> instance after the
    /// entities have been added and changes persisted. When multiple entities are provided, implementations may
    /// return the primary or first created entity, the last created entity, or another representative instance.
    /// </returns>
    Task<T> AddAsync(params T[] entities);

    /// <summary>
    /// Updates the specified entities in the repository and persists the changes.
    /// </summary>
    /// <param name="entities">One or more entity instances containing updated values.</param>
    /// <returns>
    /// A <see cref="Task{T}"/> that resolves to a representative updated <typeparamref name="T"/> instance.
    /// Implementations may return the first or last updated entity or another representative instance. If no
    /// entities were updated, the behaviour depends on the implementation.
    /// </returns>
    Task<T> UpdateAsync(params T[] entities);

    /// <summary>
    /// Deletes the specified entities from the repository asynchronously and persists the changes.
    /// </summary>
    /// <param name="entities">One or more entity instances to remove from the repository.</param>
    /// <returns>
    /// A <see cref="Task{T}"/> that resolves to a representative <typeparamref name="T"/> instance that was deleted.
    /// Implementations may return a deleted entity or a representative instance.
    /// </returns>
    Task<T> DeleteAsync(params T[] entities);
}