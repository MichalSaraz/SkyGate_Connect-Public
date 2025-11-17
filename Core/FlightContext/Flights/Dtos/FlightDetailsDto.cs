using Core.SeatContext.Enums;

namespace Core.FlightContext.Flights.Dtos;

/// <summary>
/// Represents detailed information about a flight, including its duration, 
/// airline, aircraft, status, and passenger details.
/// </summary>
public class FlightDetailsDto : FlightOverviewDto
{
    /// <summary>
    /// Gets the duration of the flight.
    /// </summary>
    public TimeSpan FlightDuration { get; init; }

    /// <summary>
    /// Gets a list of codeshare flight numbers associated with the flight.
    /// </summary>
    public string[] CodeShare { get; init; }

    /// <summary>
    /// Gets the name of the arrival airport.
    /// </summary>
    public string ArrivalAirportName { get; init; }

    /// <summary>
    /// Gets the name of the airline operating the flight.
    /// </summary>
    public string AirlineName { get; init; }

    /// <summary>
    /// Gets the registration number of the aircraft.
    /// </summary>
    public string AircraftRegistration { get; init; }

    /// <summary>
    /// Gets the type of the aircraft.
    /// </summary>
    public string AircraftType { get; init; }

    /// <summary>
    /// Gets the current status of the flight.
    /// </summary>
    public string FlightStatus { get; init; }

    /// <summary>
    /// Gets the boarding status of the flight.
    /// </summary>
    public string BoardingStatus { get; init; }

    /// <summary>
    /// Gets the total number of booked infants for the flight.
    /// </summary>
    public int TotalBookedInfants { get; init; }

    /// <summary>
    /// Gets the total number of checked-in infants for the flight.
    /// </summary>
    public int TotalCheckedInInfants { get; init; }

    /// <summary>
    /// Gets the number of booked passengers categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> BookedPassengers { get; init; }

    /// <summary>
    /// Gets the number of standby passengers categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> StandbyPassengers { get; init; }

    /// <summary>
    /// Gets the number of checked-in passengers categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> CheckedInPassengers { get; init; }

    /// <summary>
    /// Gets the aircraft configuration categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> AircraftConfiguration { get; init; }

    /// <summary>
    /// Gets the cabin capacity categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> CabinCapacity { get; init; }

    /// <summary>
    /// Gets the number of available seats categorized by flight class.
    /// </summary>
    public Dictionary<FlightClassEnum, int> AvailableSeats { get; init; }
}