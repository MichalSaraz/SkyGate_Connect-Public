namespace Core.PassengerContext.TravelDocuments.Dtos;

/// <summary>
/// Represents a travel document with details such as document number, 
/// personal information, and validity dates.
/// </summary>
public class TravelDocumentDto
{
    /// <summary>
    /// Gets the unique identifier of the travel document.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the document number of the travel document.
    /// </summary>
    public string DocumentNumber { get; init; }

    /// <summary>
    /// Gets the first name of the document holder.
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Gets the last name of the document holder.
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Gets the nationality of the document holder.
    /// </summary>
    public string Nationality { get; init; }

    /// <summary>
    /// Gets the country where the document was issued.
    /// </summary>
    public string CountryOfIssue { get; init; }

    /// <summary>
    /// Gets the type of the travel document (e.g., Passport, ID card).
    /// </summary>
    public string DocumentType { get; init; }

    /// <summary>
    /// Gets the gender of the document holder.
    /// </summary>
    public string Gender { get; init; }

    /// <summary>
    /// Gets the date of birth of the document holder.
    /// </summary>
    public DateTime DateOfBirth { get; init; }

    /// <summary>
    /// Gets the date when the document was issued.
    /// </summary>
    public DateTime DateOfIssue { get; init; }

    /// <summary>
    /// Gets the expiration date of the travel document.
    /// </summary>
    public DateTime ExpirationDate { get; init; }
}