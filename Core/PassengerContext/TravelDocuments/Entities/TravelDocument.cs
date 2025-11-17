using System.ComponentModel.DataAnnotations;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.PassengerContext.TravelDocuments.Enums;

namespace Core.PassengerContext.TravelDocuments.Entities;

/// <summary>
/// Represents a travel document associated with a passenger, including details such as 
/// nationality, country of issue, document type, and validity dates.
/// </summary>
public class TravelDocument
{
    /// <summary>
    /// Gets or sets the unique identifier of the travel document.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the passenger or item associated with the travel document.
    /// </summary>
    public BasePassengerOrItem Passenger { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the passenger associated with the travel document.
    /// </summary>
    public Guid? PassengerId { get; set; }

    /// <summary>
    /// Gets or sets the nationality of the travel document holder.
    /// </summary>
    public Country Nationality { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the nationality.
    /// </summary>
    public string NationalityId { get; set; }

    /// <summary>
    /// Gets or sets the country where the travel document was issued.
    /// </summary>
    public Country CountryOfIssue { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the country of issue.
    /// </summary>
    public string CountryOfIssueId { get; set; }

    /// <summary>
    /// Gets or sets the document number of the travel document.
    /// </summary>
    [Required]
    public string DocumentNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the travel document.
    /// </summary>
    [Required]
    public DocumentTypeEnum DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the gender of the travel document holder.
    /// </summary>
    [Required]
    public PaxGenderEnum Gender { get; set; }

    /// <summary>
    /// Gets or sets the first name of the travel document holder.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the travel document holder.
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the date of birth of the travel document holder.
    /// </summary>
    [Required]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the date when the travel document was issued.
    /// </summary>
    [Required]
    public DateTime DateOfIssue { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the travel document.
    /// </summary>
    [Required]
    public DateTime ExpirationDate { get; set; }

    public TravelDocument(
        Guid? passengerId,
        string nationalityId,
        string countryOfIssueId,
        string documentNumber,
        DocumentTypeEnum documentType,
        PaxGenderEnum gender,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        DateTime dateOfIssue,
        DateTime expirationDate)
    {
        Id = Guid.NewGuid();
        PassengerId = passengerId;
        NationalityId = nationalityId;
        CountryOfIssueId = countryOfIssueId;
        DocumentNumber = documentNumber;
        DocumentType = documentType;
        Gender = gender;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        DateOfIssue = dateOfIssue;
        ExpirationDate = expirationDate;
    }
}