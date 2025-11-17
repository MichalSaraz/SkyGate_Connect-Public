using System.ComponentModel.DataAnnotations;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.TravelDocuments.Entities;
using Core.SeatContext.Entities;

namespace Core.FlightContext.ReferenceData.Entities;

/// <summary>
/// Represents an aircraft with its associated details, such as registration code, 
/// flights, country, type, airline, seat map, and available jump seats.
/// </summary>
public class Aircraft
{
    /// <summary>
    /// Gets or sets the unique registration code of the aircraft.
    /// </summary>
    [Key]
    public string RegistrationCode { get; set; }

    /// <summary>
    /// Gets the list of flights associated with the aircraft.
    /// </summary>
    public List<Flight> Flights { get; private set; } = new();

    /// <summary>
    /// Gets or sets the country where the aircraft is registered.
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the country where the aircraft is registered.
    /// </summary>
    public string CountryId { get; set; }

    /// <summary>
    /// Gets or sets the type of the aircraft.
    /// </summary>
    public AircraftType AircraftType { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the aircraft type.
    /// </summary>
    public string AircraftTypeId { get; set; }

    /// <summary>
    /// Gets or sets the airline operating the aircraft.
    /// </summary>
    public Airline Airline { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the airline operating the aircraft.
    /// </summary>
    public string AirlineId { get; set; }

    /// <summary>
    /// Gets or sets the seat map configuration of the aircraft.
    /// </summary>
    public SeatMap SeatMap { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the seat map configuration.
    /// </summary>
    public string SeatMapId { get; set; }

    /// <summary>
    /// Gets or sets the number of available jump seats on the aircraft.
    /// </summary>
    public int JumpSeatsAvailable { get; set; }
}