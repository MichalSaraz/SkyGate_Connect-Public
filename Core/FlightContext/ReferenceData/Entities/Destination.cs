using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.TravelDocuments.Entities;

namespace Core.FlightContext.ReferenceData.Entities;

/// <summary>
/// Represents a destination, including its airport details, country, time zone,
/// and associated flight departures and arrivals.
/// </summary>
public class Destination
{
    /// <summary>
    /// Gets or sets the IATA code of the airport.
    /// </summary>
    public string IATAAirportCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the airport.
    /// </summary>
    public string AirportName { get; set; }

    /// <summary>
    /// Gets or sets the country where the destination is located.
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the country where the destination is located.
    /// </summary>
    public string CountryId { get; set; }

    /// <summary>
    /// Gets or sets the IANA time zone of the destination.
    /// </summary>
    public string IanaTimeZone { get; set; }

    /// <summary>
    /// Gets or sets the list of flights departing from the destination.
    /// </summary>
    public List<BaseFlight> Departures { get; set; }

    /// <summary>
    /// Gets or sets the list of flights arriving at the destination.
    /// </summary>
    public List<BaseFlight> Arrivals { get; set; }
}