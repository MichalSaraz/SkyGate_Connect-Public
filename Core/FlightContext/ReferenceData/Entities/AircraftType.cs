using System.ComponentModel.DataAnnotations;

namespace Core.FlightContext.ReferenceData.Entities;

/// <summary>
/// Represents a type of aircraft, including its IATA code and model name.
/// </summary>
public class AircraftType
{
    /// <summary>
    /// Gets or sets the IATA code of the aircraft type.
    /// </summary>
    [Key]
    public string AircraftTypeIATACode { get; set; }

    /// <summary>
    /// Gets or sets the model name of the aircraft type.
    /// </summary>
    public string ModelName { get; set; }
}