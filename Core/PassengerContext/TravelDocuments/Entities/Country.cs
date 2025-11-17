using System.ComponentModel.DataAnnotations;

namespace Core.PassengerContext.TravelDocuments.Entities;

/// <summary>
/// Represents a country with its associated codes, name, aircraft registration prefixes, 
/// and whether it is part of the European Economic Area (EEA).
/// </summary>
public class Country
{
    /// <summary>
    /// Gets or sets the two-letter country code (ISO 3166-1 alpha-2).
    /// </summary>
    [Key]
    public string Country2LetterCode { get; set; }

    /// <summary>
    /// Gets or sets the three-letter country code (ISO 3166-1 alpha-3).
    /// </summary>
    public string Country3LetterCode { get; set; }        

    /// <summary>
    /// Gets or sets the name of the country.
    /// </summary>
    public string CountryName { get; set; }   
        
    /// <summary>
    /// Gets or sets the aircraft registration prefixes associated with the country.
    /// </summary>
    public string[] AircraftRegistrationPrefix { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the country is part of the European Economic Area (EEA).
    /// </summary>
    public bool IsEEACountry { get; set; }
}