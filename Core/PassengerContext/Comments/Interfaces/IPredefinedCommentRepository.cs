using Core.PassengerContext.Comments.Entities;
using Core.PassengerContext.Comments.Enums;

namespace Core.PassengerContext.Comments.Interfaces;

/// <summary>
/// Defines the contract for a repository that manages <see cref="PredefinedComment"/> entities.
/// </summary>
public interface IPredefinedCommentRepository
{
    /// <summary>
    /// Retrieves a <see cref="PredefinedComment"/> based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the predefined comment.</param>
    /// <returns>
    /// A <see cref="Task{PredefinedComment}"/> that resolves to the matching <see cref="PredefinedComment"/>, or
    /// <c>null</c> if no entity with the specified identifier exists.
    /// </returns>
    Task<PredefinedComment> GetPredefinedCommentByIdAsync(PredefinedCommentEnum id);
}