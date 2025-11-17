using System.Linq.Expressions;
using Core.Abstractions;
using Core.PassengerContext.Comments.Entities;

namespace Core.PassengerContext.Comments.Interfaces;

/// <summary>
/// Repository contract for managing <see cref="Comment"/> entities. Extends the generic
/// <see cref="IGenericRepository{Comment}"/> with comment-specific data access methods. 
/// </summary>
public interface ICommentRepository : IGenericRepository<Comment>
{
    /// <summary>
    /// Retrieves a comment by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the comment to retrieve.</param>
    /// <param name="tracked">A boolean indicating whether the comment should be tracked by the context. The default
    /// value is false.</param>
    /// <returns>
    /// A <see cref="Task{Comment}"/> that resolves to the requested <see cref="Comment"/> when found, or <c>null</c>
    /// if no matching entity exists.
    /// </returns>
    Task<Comment> GetCommentByIdAsync(Guid id, bool tracked = false);

    /// <summary>
    /// Retrieves a comment based on the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria used to filter the comments.</param>
    /// <returns>
    /// A <see cref="Task{Comment}"/> that resolves to the first matching <see cref="Comment"/>, or <c>null</c> if
    /// no comment satisfies the specified criteria.
    /// </returns>
    Task<Comment> GetCommentByCriteriaAsync(Expression<Func<Comment, bool>> criteria);


    /// <summary>
    /// Retrieves a list of comments based on the specified criteria asynchronously.
    /// </summary>
    /// <param name="criteria">The criteria used to filter the comments.</param>
    /// <returns>
    /// A <see cref="Task"/> that resolves to a read-only list of matching comments (see
    /// <see cref="IReadOnlyList{Comment}"/>). The list may be empty when no comments match the criteria.
    /// </returns>
    Task<IReadOnlyList<Comment>> GetCommentsByCriteriaAsync(Expression<Func<Comment, bool>> criteria);
}