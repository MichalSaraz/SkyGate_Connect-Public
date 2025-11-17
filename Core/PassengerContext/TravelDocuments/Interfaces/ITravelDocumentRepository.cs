using Core.Abstractions;
using Core.PassengerContext.TravelDocuments.Entities;

namespace Core.PassengerContext.TravelDocuments.Interfaces;

/// <summary>
/// Repository contract for <see cref="TravelDocument"/> entities. Extends
/// <see cref="IGenericRepository{TravelDocument}"/> with queries specific to travel documents.
/// </summary>
public interface ITravelDocumentRepository : IGenericRepository<TravelDocument>
{
    /// <summary>
    /// Retrieves a travel document based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the travel document.</param>
    /// <param name="tracked">Indicates whether the travel document should be tracked for changes. Default is true.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TravelDocument}"/> that resolves to the matching <see cref="TravelDocument"/>, or
    /// <c>null</c> if no entity with the specified identifier exists.
    /// </returns>
    Task<TravelDocument> GetTravelDocumentByIdAsync(Guid id, bool tracked = true);
}