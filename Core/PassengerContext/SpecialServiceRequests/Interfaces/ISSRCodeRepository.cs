using Core.Abstractions;
using Core.PassengerContext.SpecialServiceRequests.Entities;

namespace Core.PassengerContext.SpecialServiceRequests.Interfaces;

/// <summary>
/// Repository contract for <see cref="SSRCode"/> entities. Extends <see cref="IGenericRepository{SSRCode}"/> with SSR
/// code-specific queries.
/// </summary>
public interface ISSRCodeRepository : IGenericRepository<SSRCode>
{
    /// <summary>
    /// Retrieves an <see cref="SSRCode"/> from the repository based on the provided code.
    /// </summary>
    /// <param name="code">The unique code of the SSRCode to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{SSRCode}"/> that resolves to the matching <see cref="SSRCode"/>, or <c>null</c> if
    /// no matching entity is found.
    /// </returns>
    Task<SSRCode> GetSSRCodeAsync(string code);
}