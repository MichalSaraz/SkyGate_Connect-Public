using System.ComponentModel.DataAnnotations;
using Core.PassengerContext.TravelDocuments.Entities;

namespace Core.FlightContext.ReferenceData.Entities;

/// <summary>
/// Represents an airline with its associated details, such as carrier code, country, 
/// accounting code, name, prefix, and fleet of aircraft.
/// </summary>
public class Airline
{
    /// <summary>
    /// Gets or sets the unique carrier code of the airline.
    /// </summary>
    [Key]
    public string CarrierCode { get; set; }

    /// <summary>
    /// Gets or sets the country where the airline is registered.
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the country where the airline is registered.
    /// </summary>
    public string CountryId { get; set; }

    /// <summary>
    /// Gets or sets an accounting code of the airline if available.
    /// </summary>
    public int? AccountingCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the airline.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Gets the default prefix used by the airline.
    /// </summary>
    public string AirlinePrefix { get; private set; } = "000";

    /// <summary>
    /// Gets the fleet of aircraft operated by the airline.
    /// </summary>
    public List<Aircraft> Fleet { get; private set; } = new();
}